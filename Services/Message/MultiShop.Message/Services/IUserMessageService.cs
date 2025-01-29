using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendBoxMessageDto>> GetSendboxMessageAsync(string id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessagenAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        Task<int> GetTotalMessageCount();
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
