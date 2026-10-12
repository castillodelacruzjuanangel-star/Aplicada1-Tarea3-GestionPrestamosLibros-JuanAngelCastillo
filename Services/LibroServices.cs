using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroPrestamosLibros.Context;
using RegistroPrestamosLibros.Models;

namespace RegistroPrestamosLibros.Services;

public class LibroServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Libro libro)
    {
        if (!await Existe(libro.LibroId))
        {
            return await Insertar(libro);
        }
        else
        {
            return await Modificar(libro);
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
    
    public async Task<bool> Eliminar(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
        .AsNoTracking()
        .Where(l => l.LibroId == libroId)
        .ExecuteDeleteAsync() > 0;
    }

    public async Task<Libro?> Buscar(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros.FirstOrDefaultAsync(e => e.LibroId == libroId);
    }

    public async Task<List<Libro>> GetList(Expression<Func<Libro, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
        .Where(criterio)
        .AsNoTracking()
        .ToListAsync();
    }
}
