using OfficeBoy.Domain.Interfaces;
using OfficeBoy.Models;
using System.Threading.Tasks;

public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task PlaceOrder(Order order)
    {
        

        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateOrder(Order order)
    {
        
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteOrder(Order order)
    {
        

        _unitOfWork.Orders.Delete(order);
        await _unitOfWork.CommitAsync();
    }
}
