USE [GatewayDeviceAPIMusalaSoftTest]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 7/4/2022 5:55:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


set quoted_identifier on
go
set identity_insert "Devices" on
go
ALTER TABLE "Devices" NOCHECK CONSTRAINT ALL
go
INSERT "Devices"("UID","Vendor","DateCreated","Status","GatewaySerialNumber") VALUES(1,'Samsung','2022-07-04T19:01:44.911Z','Offline','Intel Expressway 400')
INSERT "Devices"("UID","Vendor","DateCreated","Status","GatewaySerialNumber") VALUES(2,'TP-Link','2022-07-04T19:01:44.911Z','Online','Intel® Expressway 400')
INSERT "Devices"("UID","Vendor","DateCreated","Status","GatewaySerialNumber") VALUES(3,'Apple','2022-07-04T19:01:44.911Z','Online','Intel® Expressway 400')
INSERT "Devices"("UID","Vendor","DateCreated","Status","GatewaySerialNumber") VALUES(4,'Xaomi','2022-07-04T19:01:44.911Z','Online','Intel® Expressway 400')
INSERT "Devices"("UID","Vendor","DateCreated","Status","GatewaySerialNumber") VALUES(5,'Apple ','2022-07-04T19:01:44.911Z','Online','Intel® Expressway 400')
INSERT "Devices"("UID","Vendor","DateCreated","Status","GatewaySerialNumber") VALUES(6,'Cisco','2022-07-04T19:01:44.911Z','Offline','Cisco serie 3000')
INSERT "Devices"("UID","Vendor","DateCreated","Status","GatewaySerialNumber") VALUES(7,'Apple','2022-07-04T19:01:44.911Z','Offline','Cisco serie 3000')
INSERT "Devices"("UID","Vendor","DateCreated","Status","GatewaySerialNumber") VALUES(8,'Samsung','2022-07-04T19:01:44.911Z','Offline','Cisco serie 3000')
INSERT "Devices"("UID","Vendor","DateCreated","Status","GatewaySerialNumber") VALUES(9,'Cisco','2022-07-04T19:01:44.911Z','Offline','LoRaWAN Haxiot HXG3000')
INSERT "Devices"("UID","Vendor","DateCreated","Status","GatewaySerialNumber") VALUES(10,'Apple','2022-07-04T19:01:44.911Z','Offline','LoRaWAN Haxiot HXG3000')
go

/*Search data for device*/

set identity_insert "Devices" off
go
ALTER TABLE "Devices" CHECK CONSTRAINT ALL
go

set quoted_identifier on
go
set identity_insert "Gateways" on
go
ALTER TABLE "Gateways" NOCHECK CONSTRAINT ALL
go
INSERT "Gateways"("SerialNumber","Name","IPV4") VALUES('Intel® Expressway 300','Intel® Expressway','212.227.142.131')
INSERT "Gateways"("SerialNumber","Name","IPV4") VALUES('DAS PDSM-721','ICP','212.227.142.131')
INSERT "Gateways"("SerialNumber","Name","IPV4") VALUES('LoRaWAN Haxiot HXG3000','LoRaWAN Haxiot HXG','212.227.142.132')
INSERT "Gateways"("SerialNumber","Name","IPV4") VALUES('LoRaWAN Haxiot  HXGW470','LoRaWAN Haxiot HXG','212.227.142.133')
INSERT "Gateways"("SerialNumber","Name","IPV4") VALUES('LoRaWAN Haxiot HXGW900','LoRaWAN Haxiot HXG','212.227.142.134')
INSERT "Gateways"("SerialNumber","Name","IPV4") VALUES('ANT-916-CW-HWR-SMA','ANT','212.227.142.135')
INSERT "Gateways"("SerialNumber","Name","IPV4") VALUES('ICP DAS PDSM-530','ICP DAS','212.227.142.136')
INSERT "Gateways"("SerialNumber","Name","IPV4") VALUES('Cisco serie 2000','Cisco','212.227.142.137')
INSERT "Gateways"("SerialNumber","Name","IPV4") VALUES('Intel® Expressway 400','Intel® Expressway','212.227.142.138')
INSERT "Gateways"("SerialNumber","Name","IPV4") VALUES('Cisco serie 3000','Cisco','212.227.142.139')
go

/*Search data for device*/

set identity_insert "Gateways" off
go
ALTER TABLE "Gateways" CHECK CONSTRAINT ALL
go