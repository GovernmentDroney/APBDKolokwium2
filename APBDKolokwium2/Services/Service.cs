using APBDKolokwium2.Data;

namespace APBDKolokwium2.Services;

public class Service : IService
{
    private readonly DatabaseContext _context;

    public Service(DatabaseContext context)
    {
        _context = context;
    }
}