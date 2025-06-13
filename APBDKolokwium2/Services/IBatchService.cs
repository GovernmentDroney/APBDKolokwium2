using APBDKolokwium2.DTOs;

namespace APBDKolokwium2.Services;

public interface IBatchService
{
    Task PostBatch(PostBatchDTO batch);
}