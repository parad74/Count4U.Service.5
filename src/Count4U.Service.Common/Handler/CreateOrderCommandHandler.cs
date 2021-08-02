//смотри https://docs.microsoft.com/ru-ru/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-api
//Этот класс использует внедренные репозитории для выполнения транзакции и сохранения изменений состояния
namespace Count4U.Service.Common.Handler
{
	//public class CreateOrderCommandHandler
	//: IAsyncRequestHandler<CreateOrderCommand, bool>
	//{
	//	private readonly IOrderRepository _orderRepository;
	//	private readonly IIdentityService _identityService;
	//	private readonly IMediator _mediator;

	//	// Using DI to inject infrastructure persistence Repositories
	//	public CreateOrderCommandHandler(IMediator mediator,
	//									 IOrderRepository orderRepository,
	//									 IIdentityService identityService)
	//	{
	//		_orderRepository = orderRepository ??
	//						  throw new ArgumentNullException(nameof(orderRepository));
	//		_identityService = identityService ??
	//						  throw new ArgumentNullException(nameof(identityService));
	//		_mediator = mediator ??
	//								 throw new ArgumentNullException(nameof(mediator));
	//	}

	//	public async Task<bool> Handle(CreateOrderCommand message)
	//	{
	//		// Create the Order AggregateRoot
	//		// Add child entities and value objects through the Order aggregate root
	//		// methods and constructor so validations, invariants, and business logic
	//		// make sure that consistency is preserved across the whole aggregate
	//		var address = new Address(message.Street, message.City, message.State,
	//								  message.Country, message.ZipCode);
	//		var order = new Order(message.UserId, address, message.CardTypeId,
	//							  message.CardNumber, message.CardSecurityNumber,
	//							  message.CardHolderName, message.CardExpiration);

	//		foreach (var item in message.OrderItems)
	//		{
	//			order.AddOrderItem(item.ProductId, item.ProductName, item.UnitPrice,
	//							   item.Discount, item.PictureUrl, item.Units);
	//		}

	//		_orderRepository.Add(order);

	//		return await _orderRepository.UnitOfWork
	//			.SaveEntitiesAsync();
	//	}
	//}
}
