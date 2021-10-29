using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GP.WorldpayGateway
{
	[XmlRoot(ElementName = "amount")]
	public class Amount
	{
		[XmlAttribute(AttributeName = "currencyCode")]
		public string CurrencyCode { get; set; }
		[XmlAttribute(AttributeName = "exponent")]
		public string Exponent { get; set; }
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName = "debitCreditIndicator")]
		public string DebitCreditIndicator { get; set; }
	}

	[XmlRoot(ElementName = "date")]
	public class Date
	{
		[XmlAttribute(AttributeName = "month")]
		public string Month { get; set; }
		[XmlAttribute(AttributeName = "year")]
		public string Year { get; set; }
		[XmlAttribute(AttributeName = "dayOfMonth")]
		public string DayOfMonth { get; set; }
		[XmlAttribute(AttributeName = "hour")]
		public string Hour { get; set; }
		[XmlAttribute(AttributeName = "minute")]
		public string Minute { get; set; }
		[XmlAttribute(AttributeName = "second")]
		public string Second { get; set; }
	}

	[XmlRoot(ElementName = "expiryDate")]
	public class ExpiryDate
	{
		[XmlElement(ElementName = "date")]
		public Date Date { get; set; }
	}

	[XmlRoot(ElementName = "address")]
	public class Address
	{
		[XmlElement(ElementName = "address1")]
		public string Address1 { get; set; }
		[XmlElement(ElementName = "address2")]
		public string Address2 { get; set; }
		[XmlElement(ElementName = "address3")]
		public string Address3 { get; set; }
		[XmlElement(ElementName = "postalCode")]
		public string PostalCode { get; set; }
		[XmlElement(ElementName = "city")]
		public string City { get; set; }
		[XmlElement(ElementName = "state")]
		public string State { get; set; }
		[XmlElement(ElementName = "countryCode")]
		public string CountryCode { get; set; }
		[XmlElement(ElementName = "telephoneNumber")]
		public string TelephoneNumber { get; set; }
	}

	[XmlRoot(ElementName = "cardAddress")]
	public class CardAddress
	{
		[XmlElement(ElementName = "address")]
		public Address Address { get; set; }
	}

	[XmlRoot(ElementName = "VISA-SSL")]
	public class VISASSL
	{
		[XmlElement(ElementName = "cardNumber")]
		public string CardNumber { get; set; }
		[XmlElement(ElementName = "expiryDate")]
		public ExpiryDate ExpiryDate { get; set; }
		[XmlElement(ElementName = "cardHolderName")]
		public string CardHolderName { get; set; }
		[XmlElement(ElementName = "cvc")]
		public string Cvc { get; set; }
		[XmlElement(ElementName = "cardAddress")]
		public CardAddress CardAddress { get; set; }
	}

	[XmlRoot(ElementName = "session")]
	public class Session
	{
		[XmlAttribute(AttributeName = "shopperIPAddress")]
		public string ShopperIPAddress { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "paymentDetails")]
	public class PaymentDetails
	{
		[XmlElement(ElementName = "VISA-SSL")]
		public VISASSL VISASSL { get; set; }
		[XmlElement(ElementName = "session")]
		public Session Session { get; set; }
	}

	[XmlRoot(ElementName = "browser")]
	public class Browser
	{
		[XmlElement(ElementName = "acceptHeader")]
		public string AcceptHeader { get; set; }
		[XmlElement(ElementName = "userAgentHeader")]
		public string UserAgentHeader { get; set; }
	}

	[XmlRoot(ElementName = "shopper")]
	public class Shopper
	{
		[XmlElement(ElementName = "shopperEmailAddress")]
		public string ShopperEmailAddress { get; set; }
		[XmlElement(ElementName = "authenticatedShopperID")]
		public string AuthenticatedShopperID { get; set; }
		[XmlElement(ElementName = "browser")]
		public Browser Browser { get; set; }
	}

	[XmlRoot(ElementName = "paymentTokenExpiry")]
	public class PaymentTokenExpiry
	{
		[XmlElement(ElementName = "date")]
		public Date Date { get; set; }
	}

	[XmlRoot(ElementName = "createToken")]
	public class CreateToken
	{
		[XmlElement(ElementName = "tokenEventReference")]
		public string TokenEventReference { get; set; }
		[XmlElement(ElementName = "tokenReason")]
		public string TokenReason { get; set; }
		[XmlElement(ElementName = "paymentTokenExpiry")]
		public PaymentTokenExpiry PaymentTokenExpiry { get; set; }
		[XmlAttribute(AttributeName = "tokenScope")]
		public string TokenScope { get; set; }
	}

	[XmlRoot(ElementName = "order")]
	public class Order
	{
		[XmlElement(ElementName = "description")]
		public string Description { get; set; }
		[XmlElement(ElementName = "amount")]
		public Amount Amount { get; set; }
		[XmlElement(ElementName = "paymentDetails")]
		public PaymentDetails PaymentDetails { get; set; }
		[XmlElement(ElementName = "shopper")]
		public Shopper Shopper { get; set; }
		[XmlElement(ElementName = "createToken")]
		public CreateToken CreateToken { get; set; }
		[XmlAttribute(AttributeName = "orderCode")]
		public string OrderCode { get; set; }
	}

	[XmlRoot(ElementName = "submit")]
	public class Submit
	{
		[XmlElement(ElementName = "order")]
		public Order Order { get; set; }

		[XmlElement(ElementName = "paymentTokenCreate")]
		public PaymentTokenCreate PaymentTokenCreate { get; set; }
	}

	[XmlRoot(ElementName = "paymentService")]
	public class PaymentService
	{
		[XmlElement(ElementName = "submit")]
		public Submit Submit { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName = "merchantCode")]
		public string MerchantCode { get; set; }
		[XmlElement(ElementName = "reply")]
		public Reply Reply { get; set; }
	}

	[XmlRoot(ElementName = "AuthorisationId")]
	public class AuthorisationId
	{
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "balance")]
	public class Balance
	{
		[XmlElement(ElementName = "amount")]
		public Amount Amount { get; set; }
		[XmlAttribute(AttributeName = "accountType")]
		public string AccountType { get; set; }
	}

	[XmlRoot(ElementName = "riskScore")]
	public class RiskScore
	{
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "payment")]
	public class Payment
	{
		[XmlElement(ElementName = "paymentMethod")]
		public string PaymentMethod { get; set; }
		[XmlElement(ElementName = "amount")]
		public Amount Amount { get; set; }
		[XmlElement(ElementName = "lastEvent")]
		public string LastEvent { get; set; }
		[XmlElement(ElementName = "AuthorisationId")]
		public AuthorisationId AuthorisationId { get; set; }
		[XmlElement(ElementName = "balance")]
		public Balance Balance { get; set; }
		[XmlElement(ElementName = "cardNumber")]
		public string CardNumber { get; set; }
		[XmlElement(ElementName = "riskScore")]
		public RiskScore RiskScore { get; set; }
	}

	[XmlRoot(ElementName = "orderStatus")]
	public class OrderStatus
	{
		[XmlElement(ElementName = "payment")]
		public Payment Payment { get; set; }
		[XmlAttribute(AttributeName = "orderCode")]
		public string OrderCode { get; set; }

		[XmlElement(ElementName = "token")]
		public Token Token { get; set; }
	}

	[XmlRoot(ElementName = "reply")]
	public class Reply
	{
		[XmlElement(ElementName = "orderStatus")]
		public OrderStatus OrderStatus { get; set; }

		[XmlElement(ElementName = "token")]
		public Token Token { get; set; }
	}

	[XmlRoot(ElementName = "token")]
	public class Token
	{
		[XmlElement(ElementName = "authenticatedShopperID")]
		public string AuthenticatedShopperID { get; set; }
		[XmlElement(ElementName = "tokenEventReference")]
		public string TokenEventReference { get; set; }
		[XmlElement(ElementName = "tokenReason")]
		public string TokenReason { get; set; }
		[XmlElement(ElementName = "tokenDetails")]
		public TokenDetails TokenDetails { get; set; }
		[XmlElement(ElementName = "paymentInstrument")]
		public PaymentInstrument PaymentInstrument { get; set; }
	}

	[XmlRoot(ElementName = "tokenDetails")]
	public class TokenDetails
	{
		[XmlElement(ElementName = "paymentTokenID")]
		public string PaymentTokenID { get; set; }
		[XmlElement(ElementName = "paymentTokenExpiry")]
		public PaymentTokenExpiry PaymentTokenExpiry { get; set; }
		[XmlElement(ElementName = "tokenEventReference")]
		public string TokenEventReference { get; set; }
		[XmlElement(ElementName = "tokenReason")]
		public string TokenReason { get; set; }
		[XmlAttribute(AttributeName = "tokenEvent")]
		public string TokenEvent { get; set; }
	}

	[XmlRoot(ElementName = "paymentTokenCreate")]
	public class PaymentTokenCreate
	{
		[XmlElement(ElementName = "authenticatedShopperID")]
		public string AuthenticatedShopperID { get; set; }
		[XmlElement(ElementName = "createToken")]
		public CreateToken CreateToken { get; set; }
		[XmlElement(ElementName = "paymentInstrument")]
		public PaymentInstrument PaymentInstrument { get; set; }
	}

	[XmlRoot(ElementName = "paymentInstrument")]
	public class PaymentInstrument
	{
		[XmlElement(ElementName = "cardDetails")]
		public CardDetails CardDetails { get; set; }
	}

	[XmlRoot(ElementName = "cardDetails")]
	public class CardDetails
	{
		[XmlElement(ElementName = "cardNumber")]
		public string CardNumber { get; set; }
		[XmlElement(ElementName = "expiryDate")]
		public ExpiryDate ExpiryDate { get; set; }
		[XmlElement(ElementName = "cardHolderName")]
		public string CardHolderName { get; set; }
		[XmlElement(ElementName = "cardAddress")]
		public CardAddress CardAddress { get; set; }
	}
}
