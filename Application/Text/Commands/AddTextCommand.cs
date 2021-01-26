using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Stores;

namespace Application.Text.Commands
{
    public class AddTextCommand : IRequest<int>
    {
        public string Text { get; set; }

        public AddTextCommand(string text)
        {
            this.Text = text;
        }

        public class AddTextCommandHandler : IRequestHandler<AddTextCommand, int>
        {
            private readonly ITextStore _store;

            public AddTextCommandHandler(ITextStore store)
            {
                _store = store;
            }

            public async Task<int> Handle(AddTextCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var textEntity = new TextEntity(request.Text);
                    var result = await _store.AddAsync(textEntity);
                    return result;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}
