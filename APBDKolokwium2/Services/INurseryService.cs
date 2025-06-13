using APBDKolokwium2.DTOs;

namespace APBDKolokwium2.Services;

public interface INurseryService
{
    Task<GetNurseryDTO> GetNursery(int id);
}