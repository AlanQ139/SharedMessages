namespace Shared.Contracts;

/// <summary>
/// Evento publicado quando um usuário compra um jogo
/// MassTransit usa interfaces para contratos (convenção recomendada)
/// </summary>
public interface IGamePurchased
{
    Guid PurchaseId { get; }
    Guid UserId { get; }
    Guid GameId { get; }
    decimal GamePrice { get; }
    DateTime PurchaseDate { get; }
}

/// <summary>
/// Evento publicado quando o pagamento é processado
/// </summary>
public interface IPaymentProcessed
{
    Guid PaymentId { get; }
    Guid PurchaseId { get; }
    Guid UserId { get; }
    Guid GameId { get; }
    decimal Amount { get; }
    PaymentStatus Status { get; }
    DateTime ProcessedAt { get; }
    string? ErrorMessage { get; }
}

/// <summary>
/// Evento publicado quando um novo usuário se registra
/// </summary>
public interface IUserRegistered
{
    Guid UserId { get; }
    string Email { get; }
    string Name { get; }
    DateTime RegisteredAt { get; }
}

/// <summary>
/// Comando para processar um pagamento
/// Diferença: Commands são imperativos, Events são fatos passados
/// </summary>
public interface IProcessPayment
{
    Guid PurchaseId { get; }
    Guid UserId { get; }
    Guid GameId { get; }
    decimal Amount { get; }
}

public enum PaymentStatus
{
    Pending,
    Processing,
    Paid,
    Failed,
    Refunded
}