using Microsoft.EntityFrameworkCore;
using Context;
using Models;
using System.Linq.Expressions;

namespace Services;

public class PrestamoLibroServices(IDbContextFactory<Contexto> contextFactory) : Aplicada1.Core.IService<Prestamos, int>
{
    private async Task<bool> Existe(int PrestamoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.PrestamosLibros.AnyAsync(p => p.PrestamoId == PrestamoId);     
    }

    public async Task<bool> Guardar(Prestamos prestamo)
    {
        var existePrestamo = Existe(prestamo.PrestamoId);

        if (!await existePrestamo)
        {
            return await Insertar(prestamo);
        }
        else
        {
            return await Modificar(prestamo);
        }
    }

    private async Task<bool> Insertar(Prestamos prestamo)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.PrestamosLibros.Add(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prestamos prestamo)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.PrestamosLibros.Update(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Prestamos?> Buscar(int PrestamoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.PrestamosLibros
        .Include(e => e.Estudiante)
        .FirstOrDefaultAsync(p => p.PrestamoId == PrestamoId);
    }

    public async Task<bool> Eliminar(int PrestamoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.PrestamosLibros.AsNoTracking().Where(p => p.PrestamoId == PrestamoId).ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Prestamos>> GetList(Expression<Func<Prestamos, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.PrestamosLibros
        .Include(e => e.Estudiante)
        .Where(criterio)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<List<Prestamos>> GetPrestamosPrendientes(int EstudianteId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.PrestamosLibros
        .Where(e => e.EstudianteId == EstudianteId)
        .OrderBy(p => p.PrestamoId)
        .AsNoTracking()
        .ToListAsync();
    }
}

