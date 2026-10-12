using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using RegistroPrestamosLibros.Context;
using RegistroPrestamosLibros.Models;

namespace RegistroPrestamosLibros.Services;

public class PrestamoServices(IDbContextFactory<Contexto> contextFactory) 
    : Aplicada1.Core.IServiceResult<Prestamos, int>
{
    public async Task<Result> Guardar(Prestamos prestamo)
    {
        if(!await Existe(prestamo.PrestamoId))
        {
            var insertar = await Insertar(prestamo);
            return Result.Success(insertar);
        }
        else
        {
            var modificar =  await Modificar(prestamo);
            return Result.Success(modificar);
        }
    }

    private async Task<bool> Existe(int PrestamoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.PrestamosLibros.AnyAsync(p => p.PrestamoId == PrestamoId);
    }    

    private async Task<bool> Insertar(Prestamos prestamo)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var libro = await contexto.Libros.FindAsync(prestamo.LibroId);
        if(libro == null || !libro.EstaDisponible)
        {
            return false;
        }
        libro.EstaDisponible = false;
        contexto.PrestamosLibros.Add(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    } 

    private async Task<bool> Modificar(Prestamos prestamo)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var prestamoAnterior = await contexto.PrestamosLibros
                            .AsNoTracking()
                            .FirstOrDefaultAsync(p => p.PrestamoId == prestamo.PrestamoId);
        if(prestamoAnterior == null)
            return false;

        if(prestamoAnterior.LibroId != prestamo.PrestamoId)
        {
            var libroNuevo = await contexto.Libros.FindAsync(prestamo.LibroId);
            if(libroNuevo == null)
                return false;

            var libroAnterior = await contexto.Libros.FindAsync(prestamoAnterior.LibroId);
            if(libroAnterior != null)
                libroAnterior.EstaDisponible = true;

            libroNuevo.EstaDisponible = false;
        }
        contexto.PrestamosLibros.Update(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result> Eliminar(int prestamoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var prestamo = await contexto.PrestamosLibros.FindAsync(prestamoId);
        if(prestamo == null)
            return Result.Failure(Error.None);

        var libro = await contexto.Libros.FindAsync(prestamo.LibroId);
        if(libro != null)
            libro.EstaDisponible = true;

        contexto.PrestamosLibros.Remove(prestamo);
        var eliminado =  await contexto.SaveChangesAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<Result<Prestamos?>> Buscar(int prestamoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.PrestamosLibros
        .Include(p => p.Estudiante)
        .Include(p => p.Libro)
        .FirstOrDefaultAsync(p => p.PrestamoId == prestamoId);
    }

    public async Task<Result<List<Prestamos>>> GetList(Expression<Func<Prestamos, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.PrestamosLibros
        .Include(p => p.Estudiante)
        .Include(p => p.Libro)
        .Where(criterio)
        .AsNoTracking()
        .ToListAsync();
    }
}
