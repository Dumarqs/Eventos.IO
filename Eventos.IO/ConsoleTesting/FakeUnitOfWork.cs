using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Interfaces;

public class FakeUnitOfWork : IUnitOfWork
{
    public CommandResponse Commit()
    {
        return new CommandResponse(true);
    }

    public void Dispose()
    {
        //
    }
}