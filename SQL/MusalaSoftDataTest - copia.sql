USE [GatewayDeviceAPIMusalaSoftTest]
GO
SET IDENTITY_INSERT [dbo].[Gateways] ON 

INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'Intel® Expressway 300', N'Intel® Expressway', N'212.227.142.135')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'DAS PDSM-721', N'ICPVa', N'10.227.142.140')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'LoRaWAN Haxiot HXG3000', N'LoRaWAN Haxiot HXG', N'212.227.142.132')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'LoRaWAN Haxiot  HXGW470', N'LoRaWAN Haxiot HXG', N'212.227.142.133')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'LoRaWAN Haxiot HXGW900', N'LoRaWAN Haxiot HXG', N'212.227.142.134')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'ANT-916-CW-HWR-SMA', N'ANT', N'212.227.142.135')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'ICP DAS PDSM-530', N'ICP DAS', N'212.227.142.136')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'Cisco serie 2000', N'Cisco', N'212.227.142.137')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'Intel® Expressway 400', N'Intel® Expressway', N'212.227.142.138')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'Cisco 520', N'Cisco', N'212.227.142.139')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'Intel Pro AB3R44', N'Intel Pro', N'120.4.5.240')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'AMD Pro B345hjlskdl', N'AMD Pro', N'10.0.0.1')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'ValquiriaSoftwkrlwkjrio', N'ValquiriaSoft', N'1.10.9.40')
INSERT [dbo].[Gateways] ([SerialNumber], [Name], [IPV4]) VALUES (N'ValquiriaSoft 300', N'ValquiriaSoft 300', N'255.10.4.125')
SET IDENTITY_INSERT [dbo].[Gateways] OFF
GO
SET IDENTITY_INSERT [dbo].[Devices] ON 

INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (1, N'Samsung Note 10', CAST(N'2022-07-04T19:01:44.9110000' AS DateTime2), N'Online', N'DAS PDSM-721')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (2, N'Other-Vendor', CAST(N'2022-07-08T23:33:22.7450000' AS DateTime2), N'Online', N'Intel® Expressway 300')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (3, N'Apple', CAST(N'2022-07-04T19:01:44.9110000' AS DateTime2), N'Online', N'Intel® Expressway 300')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (4, N'Xaomi', CAST(N'2022-07-04T19:01:44.9110000' AS DateTime2), N'Online', N'Intel® Expressway 300')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (5, N'Apple ', CAST(N'2022-07-04T19:01:44.9110000' AS DateTime2), N'Online', N'Cisco 520')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (6, N'Cisco', CAST(N'2022-07-04T19:01:44.9110000' AS DateTime2), N'Offline', N'LoRaWAN Haxiot HXGW900')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (7, N'Apple', CAST(N'2022-07-04T19:01:44.9110000' AS DateTime2), N'Offline', N'LoRaWAN Haxiot HXGW900')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (8, N'Samsung', CAST(N'2022-07-04T19:01:44.9110000' AS DateTime2), N'Offline', N'LoRaWAN Haxiot HXGW900')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (9, N'Cisco', CAST(N'2022-07-04T19:01:44.9110000' AS DateTime2), N'Online', N'LoRaWAN Haxiot HXGW900')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (11, N'samsung gallaxy', CAST(N'2022-07-05T02:49:44.2620000' AS DateTime2), N'Offline', 'Cisco 520')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (12, N'Xaomi Mi', CAST(N'2022-07-05T04:32:47.8020000' AS DateTime2), N'Online', N'Intel® Expressway 300')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (13, N'Mi Band 6', CAST(N'2022-07-05T04:32:47.8020000' AS DateTime2), N'Online', N'Intel® Expressway 300')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (14, N'Apple', CAST(N'2022-07-05T04:32:47.8020000' AS DateTime2), N'Offline', N'Intel® Expressway 300')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (15, N'Google', CAST(N'2022-07-05T04:32:47.8020000' AS DateTime2), N'Online', N'Intel® Expressway 300')
INSERT [dbo].[Devices] ([UID], [Vendor], [DateCreated], [Status], [GatewaySerialNumber]) VALUES (16, N'ABC', CAST(N'2022-07-05T04:32:47.8020000' AS DateTime2), N'Online', N'Intel® Expressway 300')
SET IDENTITY_INSERT [dbo].[Devices] OFF
GO

