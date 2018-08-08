GO
/****** Object:  User [praysoft]    Script Date: 30/05/2017 7:13:48 a. m. ******/
CREATE USER [praysoft] FOR LOGIN [praysoft] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\Seguridad]    Script Date: 30/05/2017 7:13:48 a. m. ******/
CREATE USER [IIS APPPOOL\Seguridad] FOR LOGIN [IIS APPPOOL\Seguridad] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\DefaultAppPool]    Script Date: 30/05/2017 7:13:48 a. m. ******/
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [praysoft]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Seguridad]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\DefaultAppPool]