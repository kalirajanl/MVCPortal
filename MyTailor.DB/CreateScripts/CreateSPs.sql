IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_GetOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_GetOrders
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_GetOrder]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_GetOrder
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[CST_GetCustomer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.CST_GetCustomer
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[CST_GetCustomers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.CST_GetCustomers
END
GO


IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_GetOrderPayments]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_GetOrderPayments
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_GetOrderSizes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_GetOrderSizes
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_GetOrderMaterials]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_GetOrderMaterials
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_GetOrderMaterial]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_GetOrderMaterial
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_AddOrderHeader]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_AddOrderHeader
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_UpdateOrderHeader]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_UpdateOrderHeader
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_AddUpdateOrderPayment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_AddUpdateOrderPayment
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_DeleteOrderPayments]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_DeleteOrderPayments
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_DeleteOrder]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_DeleteOrder
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_DeleteOrderPayment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_DeleteOrderPayment
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_DeleteOrderFinishedSizes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_DeleteOrderFinishedSizes
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_DeleteOrderMeasureSizes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_DeleteOrderMeasureSizes
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_AddOrderSize]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_AddOrderSize
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_DeleteOrderMaterial]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_DeleteOrderMaterial
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_DeleteOrderMaterials]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_DeleteOrderMaterials
END
GO

IF EXISTS (SELECT id FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ORD_AddUpdateOrderMaterial]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ORD_AddUpdateOrderMaterial
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.ORD_GetOrders
AS
BEGIN
	SELECT
			a.OrderID, OrderNumber, OrderDate, OrderAmount, PaidAmount, UploadedDate, HasLog, SalesManID, CCNumber, CCExpiryDate, CCOwnerName
		FROM ORD_OrderHeader a
			LEFT OUTER JOIN ORD_OrderPayments b on a.OrderID = b.OrderID and b.Sequence = 1
		ORDER BY a.OrderID DESC

END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.ORD_GetOrder
	(
		@OrderID UniqueIdentifier
	)
AS
BEGIN
	SELECT	*
		FROM ORD_OrderHeader 
		WHERE OrderID = @OrderID;

	SELECT 	*
		FROM ORD_OrderMaterials
		WHERE OrderID = @OrderID
		ORDER BY Sequence;

	SELECT  *
		FROM ORD_OrderSizes 
		WHERE OrderID = @OrderID
		ORDER BY TypeOfSize, Sequence, Caption;

	SELECT  * 
		FROM ORD_OrderPayments
		WHERE OrderID = @OrderID
		ORDER BY Sequence;
END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.CST_GetCustomer
	(
		@CustomerID UniqueIdentifier
	)
AS
BEGIN
	SELECT	*
		FROM CST_Customer 
		WHERE CustomerID = @CustomerID
END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.CST_GetCustomers
AS
BEGIN
	SELECT	*
		FROM CST_Customer 
END
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.ORD_GetOrderPayments
	(
		@OrderID UniqueIdentifier
	)
AS
BEGIN
	SELECT	*
		FROM ORD_OrderPayments 
		WHERE OrderID = @OrderID
		ORDER BY Sequence
END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.ORD_GetOrderSizes
	(
		@OrderID UniqueIdentifier
	)
AS
BEGIN
	SELECT	*
		FROM ORD_OrderSizes
		WHERE OrderID = @OrderID
		ORDER BY TypeOfSize,Sequence
END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.ORD_GetOrderMaterials
	(
		@OrderID UniqueIdentifier
	)
AS
BEGIN
	SELECT	*
		FROM ORD_OrderMaterials
		WHERE OrderID = @OrderID
		ORDER BY Sequence
END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.ORD_GetOrderMaterial
	(
		@OrderID UniqueIdentifier,
		@Sequence int
	)
AS
BEGIN
	SELECT	*
		FROM ORD_OrderMaterials
		WHERE OrderID = @OrderID
			AND Sequence = @Sequence
END
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_AddOrderHeader]
    (
	@OrderNumber char(15),
	@CustomerID uniqueidentifier,
	@OrderDate date,
	@SalesManID int,
	@StyleSummary nvarchar(max),
	@OrderAmount decimal(18,2),
	@PaidAmount decimal(18,2),
	@UploadedDate datetime,
	@HasLog bit,
	@Measure_Height nvarchar(50),
	@Measure_Weight nvarchar(50),
	@Measure_OrderInstructions nvarchar(4000),
	@ShippingCharges  decimal(18,2),
	@DutyCharges decimal(18,2),
	@OtherCharges decimal(18,2),
	@OtherChargesCaption decimal(18,2),
	@Discount decimal(18,2),
	@TaxPercentage decimal(18,2),
	@ShippingInstructions nvarchar(4000),
	@OrderRemarks nvarchar(max),
	@ShipmentType int,
	@OrderType int,
	@orderid uniqueidentifier OUTPUT)
AS
BEGIN

	Declare @id uniqueidentifier
	Select @id = NewID()

	INSERT ORD_OrderHeader
			(OrderID,OrderNumber,CustomerID,OrderDate,SalesManID,StyleSummary,OrderAmount,PaidAmount,UploadedDate,HasLog,Measure_Height,Measure_Weight,Measure_OrderInstructions,ShippingCharges,DutyCharges,OtherCharges,OtherChargesCaption,Discount,TaxPercentage,ShippingInstructions,OrderRemarks,ShipmentType,OrderType)
		VALUES
			(@id,@OrderNumber,@CustomerID,@OrderDate,@SalesManID,@StyleSummary,@OrderAmount,@PaidAmount,@UploadedDate,@HasLog,@Measure_Height,@Measure_Weight,@Measure_OrderInstructions,@ShippingCharges,@DutyCharges,@OtherCharges,@OtherChargesCaption,@Discount,@TaxPercentage,@ShippingInstructions,@OrderRemarks,@ShipmentType,@OrderType)

    SELECT @orderid = @id

    RETURN
END
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_UpdateOrderHeader]
    (
	@OrderNumber char(15),
	@CustomerID uniqueidentifier,
	@OrderDate date,
	@SalesManID int,
	@StyleSummary nvarchar(max),
	@OrderAmount decimal(18,2),
	@PaidAmount decimal(18,2),
	@UploadedDate datetime,
	@HasLog bit,
	@Measure_Height nvarchar(50),
	@Measure_Weight nvarchar(50),
	@Measure_OrderInstructions nvarchar(4000),
	@ShippingCharges  decimal(18,2),
	@DutyCharges decimal(18,2),
	@OtherCharges decimal(18,2),
	@OtherChargesCaption decimal(18,2),
	@Discount decimal(18,2),
	@TaxPercentage decimal(18,2),
	@ShippingInstructions nvarchar(4000),
	@OrderRemarks nvarchar(max),
	@ShipmentType int,
	@OrderType int,
	@orderid uniqueidentifier)
AS
BEGIN

	Declare @id uniqueidentifier
	Select @id = NewID()

	UPDATE ORD_OrderHeader
		SET
			OrderID = @OrderID,
			OrderNumber = @OrderNumber,
			CustomerID = @CustomerID,
			OrderDate = @OrderDate,
			SalesManID = @SalesManID,
			StyleSummary = @StyleSummary,
			OrderAmount = @OrderAmount,
			PaidAmount = @PaidAmount,
			UploadedDate = @UploadedDate,
			HasLog = @HasLog,
			Measure_Height = @Measure_Height,
			Measure_Weight = @Measure_Weight,
			Measure_OrderInstructions = @Measure_OrderInstructions,
			ShippingCharges = @ShippingCharges,
			DutyCharges = @DutyCharges,
			OtherCharges = @OtherCharges,
			OtherChargesCaption = @OtherChargesCaption,
			Discount = @Discount,
			TaxPercentage = @TaxPercentage,
			ShippingInstructions = @ShippingInstructions,
			OrderRemarks = @OrderRemarks,
			ShipmentType = @ShipmentType,
			OrderType  = @OrderType
		WHERE OrderID = @orderid
    RETURN
END
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_AddUpdateOrderPayment]
    (
	@OrderID UniqueIdentifier,
	@Sequence int,
	@PaymentDate datetime,
	@Amount decimal(18,2),
	@PaymentRemarks nvarchar(4000),
	@PaymentType int,
	@CCNumber nvarchar(20),
	@CCName nvarchar(50),
	@CCExpiryDate date,
	@CCOwnerName nvarchar(100),
	@CHKBankName nvarchar(250),
	@CHKOwnerName nvarchar(100),
	@CHKAmount decimal(18,2),
	@CHKNumber nvarchar(15),
	@GCNumber nvarchar(50),
	@GCTotalValue decimal(18,2),
	@GCAvailableValue  decimal(18,2)
)
AS
BEGIN

	IF EXISTS(SELECT PaymentDate FROM ORD_OrderPayments WHERE orderID = @orderid AND Sequence = @Sequence)
	BEGIN
		UPDATE ORD_OrderPayments
			SET
				PaymentDate = @PaymentDate,
				Amount = @Amount,
				PaymentRemarks = @PaymentRemarks,
				PaymentType = @PaymentType,
				CCNumber= @CCNumber,
				CCName = @CCName,
				CCExpiryDate = @CCExpiryDate,
				CCOwnerName = @CCOwnerName,
				CHKBankName = @CHKBankName,
				CHKOwnerName = @CHKOwnerName,
				CHKAmount = @CHKAmount,
				CHKNumber = @CHKNumber,
				GCNumber = @GCNumber,
				GCTotalValue = @GCTotalValue,
				GCAvailableValue = @GCAvailableValue
			WHERE orderID = @orderid AND Sequence = @Sequence
	END
	ELSE
	BEGIN
		INSERT ORD_OrderPayments
			(OrderID,Sequence,PaymentDate,Amount,PaymentRemarks,PaymentType,CCNumber,CCName,CCExpiryDate,CCOwnerName,CHKBankName,CHKOwnerName,CHKAmount,CHKNumber,GCNumber,GCTotalValue,GCAvailableValue)
			VALUES
			(@OrderID,@Sequence,@PaymentDate,@Amount,@PaymentRemarks,@PaymentType,@CCNumber,@CCName,@CCExpiryDate,@CCOwnerName,@CHKBankName,@CHKOwnerName,@CHKAmount,@CHKNumber,@GCNumber,@GCTotalValue,@GCAvailableValue)
	END
END
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_DeleteOrderPayments]
    (
	@OrderID UniqueIdentifier,
	@Sequences nvarchar(max)
	)
AS
BEGIN
	IF (@Sequences = '')
	BEGIN
		DELETE FROM ORD_OrderPayments WHERE OrderID = @OrderID
	END
	ELSE
	BEGIN
		DELETE FROM ORD_OrderPayments WHERE OrderID = @OrderID AND Sequence NOT IN (@Sequences)
	END
END 
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_DeleteOrderPayment]
    (
	@OrderID UniqueIdentifier,
	@Sequence int
	)
AS
BEGIN
	DELETE FROM ORD_OrderPayments WHERE OrderID = @OrderID AND Sequence = @Sequence
END 
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_DeleteOrderFinishedSizes]
    (
	@OrderID UniqueIdentifier
	)
AS
BEGIN
		DELETE FROM ORD_OrderSizes WHERE OrderID = @OrderID AND TypeOfSize IN (4,5,6)
END 
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_DeleteOrderMeasureSizes]
    (
	@OrderID UniqueIdentifier
	)
AS
BEGIN
		DELETE FROM ORD_OrderSizes WHERE OrderID = @OrderID AND TypeOfSize IN (1,2,3)
END 
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_AddOrderSize]
    (
	@OrderID UniqueIdentifier, 
	@TypeOfSize int,
	@Caption nvarchar(50),
	@Value nvarchar(50),
	@Sequence int
	)
AS
BEGIN
		INSERT INTO ORD_OrderSizes
           (OrderID,TypeOfSize,Caption,Value,Sequence)
		   VALUES
		   (@OrderID,@TypeOfSize,@Caption,@Value,@Sequence)

END 
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_DeleteOrderMaterial]
    (
	@OrderID UniqueIdentifier,
	@Sequence int
	)
AS
BEGIN
	DELETE FROM ORD_OrderMaterials WHERE OrderID = @OrderID AND Sequence = @Sequence
END 
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_DeleteOrderMaterials]
    (
	@OrderID UniqueIdentifier,
	@Sequences nvarchar(max)
	)
AS
BEGIN
	IF (@Sequences = '')
	BEGIN
		DELETE FROM ORD_OrderMaterials WHERE OrderID = @OrderID
	END
	ELSE
	BEGIN
		DELETE FROM ORD_OrderMaterials WHERE OrderID = @OrderID AND Sequence NOT IN (@Sequences)
	END
END 
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_AddUpdateOrderMaterial]
    (
	@OrderID UniqueIdentifier,
	@Sequence int,
	@MaterialName nvarchar(100),
	@MaterialDescription nvarchar(4000),
	@ItemType int,
	@Quantity int ,
	@Price decimal(18,2),
	@SubItem1Type int,
	@SubItem1Name nvarchar(100),
	@SubItem1Qty int,
	@SubItem1Price decimal(18,2),
	@SubItem2Type int,
	@SubItem2Name nvarchar(100),
	@SubItem2Qty int,
	@SubItem2Price decimal(18,2),
	@Yardage decimal(18,3),
	@TailorID int,
	@Color nvarchar(50),
	@Pattern nvarchar(50),
	@Category nvarchar(50),
	@FabricWidth  int,
	@IncludeSlackHalfLining bit,
	@IncludeSlackFullLining bit,
	@IncludeRBHole bit,
	@IncludeHSEdges bit,
	@IncludeMono bit,
	@IncludePB bit,
	@IncludeWCC bit,
	@IncludeWC bit,
	@IncludeSS bit,
	@IncludeFT bit
)
AS
BEGIN

	IF EXISTS(SELECT PaymentDate FROM ORD_OrderPayments WHERE orderID = @orderid AND Sequence = @Sequence)
	BEGIN
		UPDATE ORD_OrderMaterials
			SET
				MaterialName = @MaterialName,
				MaterialDescription = @MaterialDescription,
				ItemType = @ItemType,
				Quantity = @Quantity,
				Price = @Price,
				SubItem1Type = @SubItem1Type,
				SubItem1Name = @SubItem1Name,
				SubItem1Qty = @SubItem1Qty,
				SubItem1Price = @SubItem1Price,
				SubItem2Type = @SubItem2Type,
				SubItem2Name = @SubItem2Name,
				SubItem2Qty = @SubItem2Qty,
				SubItem2Price = @SubItem2Price ,
				Yardage = @Yardage,
				TailorID = @TailorID,
				Color = @Color,
				Pattern = @Pattern,
				Category = @Category,
				FabricWidth = @FabricWidth,
				IncludeSlackHalfLining = @IncludeSlackHalfLining,
				IncludeSlackFullLining = @IncludeSlackFullLining,
				IncludeRBHole = @IncludeRBHole,
				IncludeHSEdges = @IncludeHSEdges,
				IncludeMono = @IncludeMono,
				IncludePB = @IncludePB,
				IncludeWCC = @IncludeWCC,
				IncludeWC = @IncludeWC,
				IncludeSS = @IncludeSS,
				IncludeFT = @IncludeFT
			WHERE orderID = @orderid AND Sequence = @Sequence
	END
	ELSE
	BEGIN
		INSERT ORD_OrderMaterials
			(OrderID,Sequence,MaterialName,MaterialDescription,ItemType,Quantity,Price,SubItem1Type,SubItem1Name,SubItem1Qty,SubItem1Price,SubItem2Type,SubItem2Name,SubItem2Qty,SubItem2Price,Yardage,TailorID,Color,Pattern,Category,FabricWidth,IncludeSlackHalfLining,IncludeSlackFullLining,IncludeRBHole,IncludeHSEdges,IncludeMono,IncludePB,IncludeWCC,IncludeWC,IncludeSS,IncludeFT)
			VALUES
			(@OrderID,@Sequence,@MaterialName,@MaterialDescription,@ItemType,@Quantity,@Price,@SubItem1Type,@SubItem1Name,@SubItem1Qty,@SubItem1Price,@SubItem2Type,@SubItem2Name,@SubItem2Qty,@SubItem2Price,@Yardage,@TailorID,@Color,@Pattern,@Category,@FabricWidth,@IncludeSlackHalfLining,@IncludeSlackFullLining,@IncludeRBHole,@IncludeHSEdges,@IncludeMono,@IncludePB,@IncludeWCC,@IncludeWC,@IncludeSS,@IncludeFT)
	END
END
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ORD_DeleteOrder]
    (
	@OrderID UniqueIdentifier
	)
AS
BEGIN
	DELETE FROM ORD_OrderPayments WHERE OrderID = @OrderID
	DELETE FROM ORD_OrderSizes WHERE OrderID = @OrderID
	DELETE FROM ORD_OrderMaterials WHERE OrderID = @OrderID
	DELETE FROM ORD_OrderHeader WHERE OrderID = @OrderID
END 
Go
