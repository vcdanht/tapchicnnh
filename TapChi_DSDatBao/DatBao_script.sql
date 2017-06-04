CREATE TABLE DatBao
    (
    DatBaoId int NOT NULL IDENTITY (1, 1),
    Ten nvarchar(MAX) NOT NULL,
	GioiTinh int not null,
    DonViCongtac nvarchar(MAX)  NULL,
    DiaChi nvarchar(MAX)  NULL,
	DienThoai nvarchar(MAX)  NULL,
	Email nvarchar(MAX) NOT NULL,
	KyHan int NOT NULL,
	NoiDung nvarchar(MAX) NOT NULL,
	HinhThucThanhToan varchar(20) NOT NULL,
    CreatedOnDate datetime NOT NULL,    
    LastModifiedOnDate datetime NOT NULL,
	Status int null
    )  ON [PRIMARY]
     TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE DatBao ADD CONSTRAINT
    PK_DatBao PRIMARY KEY CLUSTERED 
    (
    DatBaoId
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO