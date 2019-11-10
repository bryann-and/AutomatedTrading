CREATE TABLE Usuario (
  Id bigint IDENTITY,
  IdPessoa bigint NOT NULL,
  CONSTRAINT PK_Usuario_Id PRIMARY KEY CLUSTERED (Id)
);

ALTER TABLE Usuario
  ADD CONSTRAINT FK_Usuario_IdPessoa FOREIGN KEY (IdPessoa) REFERENCES dbo.Pessoa (Id);