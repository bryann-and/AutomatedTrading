CREATE TABLE AutoTrading.dbo.OrderCoinBase (
  BaseOrderId bigint NOT NULL,
  OrderId varchar(100) NOT NULL,
  Status tinyint NULL,
  ProductId varchar(10) NOT NULL,
  Price decimal NOT NULL,
  Funds decimal NOT NULL,
  Stp char(2) NOT NULL DEFAULT ('DC'),
  TimeInForce char(3) NOT NULL DEFAULT ('GTC'),
  PostOnly bit NULL,
  CreatedAt datetime NULL,
  FillFees decimal NULL,
  FilledSize decimal NULL,
  ExecutedValue decimal NULL,
  Settled bit NULL
);


ALTER TABLE AutoTrading.dbo.OrderCoinBase
  ADD CONSTRAINT FK_OrderCoinBase_OrderBase_Id FOREIGN KEY (BaseOrderId) REFERENCES dbo.OrderBase (Id);