using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using RegistroPrestamosLibros.Context;
using RegistroPrestamosLibros.Models;

namespace RegistroPrestamosLibros.Services;

public class LibroServices(IDbContextFactory<Contexto> DbFactory) : Aplicada1.Core.IServiceResult<Libro, int>
{
    public async Task<Result> Guardar(Libro libro)
    {
        if (!await Existe(libro.LibroId))
        {
            var insertar = await Insertar(libro);
            return Result.Success(insertar);
        }
        else
        {
            var modificar = await Modificar(libro);
            return Result.Success(modificar);
        }
    }

    public async Task<bool> Existe(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros.AnyAsync(l => l.LibroId == libroId);
    }

    public async Task<bool> Modificar(Libro libro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Libros.Update(libro);
        return await contexto.SaveChangesAsync() > 0;
    }
    
    public async Task<bool> Insertar(Libro libro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Libros.Add(libro);
        return await contexto.SaveChangesAsync() > 0;
    }
    
    public async Task<Result> Eliminar(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminar = await contexto.Libros
        .AsNoTracking()
        .Where(l => l.LibroId == libroId)
        .ExecuteDeleteAsync() > 0;

        return Result.Success(eliminar);
    }

    public async Task<Result<Libro?>> Buscar(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros.FirstOrDefaultAsync(e => e.LibroId == libroId);
    }

    public async Task<Result<List<Libro>>> GetList(Expression<Func<Libro, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
        .Where(criterio)
        .AsNoTracking()
        .ToListAsync();
    }
}
