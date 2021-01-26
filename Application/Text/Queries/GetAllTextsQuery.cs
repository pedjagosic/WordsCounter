using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dto;
using Application.Stores;
using MediatR;

namespace Application.Text.Queries
{
    public class GetAllTextsQuery : IRequest<IEnumerable<TextDto>>
    {
        public GetAllTextsQuery()
        {
            
        }
        
        public class GetAllTextsQueryHandler : IRequestHandler<GetAllTextsQuery,IEnumerable<TextDto>>
        {
            private readonly ITextStore _store;

            public GetAllTextsQueryHandler(ITextStore store)
            {
                _store = store;
            }
            
            public async Task<IEnumerable<TextDto>> Handle(GetAllTextsQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var texts =  await _store.GetAllAsync();
                    return texts;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}