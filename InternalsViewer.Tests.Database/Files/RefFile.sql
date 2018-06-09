ALTER DATABASE [$(DatabaseName)]
    ADD FILE
    (
        NAME = [RefFile],
        FILENAME = '$(DefaultDataPath)$(DefaultFilePrefix)_RefFile.ndf'
    )
GO
