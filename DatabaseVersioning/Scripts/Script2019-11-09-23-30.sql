CREATE TABLE BaseOrder (
  Id bigint IDENTITY,
  IdUsuario bigint NOT NULL,
  Lado tinyint NOT NULL,
  Tipo tinyint NOT NULL,
  CONSTRAINT PK_Order_Id PRIMARY KEY CLUSTERED (Id)
);

ALTER TABLE BaseOrder
  ADD CONSTRAINT FK_Order_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario (Id);

EXEC sys.sp_addextendedproperty N'MS_Description'
                               ,'O lado da ordem: Compra/Venda'
                               ,'SCHEMA'
                               ,N'dbo'
                               ,'TABLE'
                               ,N'BaseOrder'
                               ,'COLUMN'
                               ,N'Lado';

EXEC sys.sp_addextendedproperty N'MS_Description'
                               ,'O Tipo de ordem: Market/Limit'
                               ,'SCHEMA'
                               ,N'dbo'
                               ,'TABLE'
                               ,N'BaseOrder'
                               ,'COLUMN'
                               ,N'Tipo';