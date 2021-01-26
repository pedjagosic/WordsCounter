using System.Linq;
using Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Application.Extensions;
using Application.Stores;
using Shared.Enumerations;

namespace Application.Text.Queries
{
    public class GetTextQuery : IRequest<int>
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public TextType SelectedTextType { get; set; }

        public GetTextQuery(string textTypeId, string text = null, string id = null)
        {
            Id = id;
            Text = text;
            SelectedTextType = TextType.FromId(textTypeId);
        }

        public class GetTextQueryHandler : IRequestHandler<GetTextQuery, int>
        {
            private readonly ITextStore _store;

            public GetTextQueryHandler(ITextStore store)
            {
                _store = store;
            }

            public async Task<int> Handle(GetTextQuery request, CancellationToken cancellationToken)
            {
                if (request.SelectedTextType.Id != TextType.TextCountFromDb.Id)
                    return request.Text.GetCountOfWordsFromText();
                
                var book = await _store.FindByIdAsync(new GetTextQuery(request.Id));
                return book.GetCountOfWordsFromText();

            }
        }
    }
}