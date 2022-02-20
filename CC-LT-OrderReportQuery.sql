
CREATE VIEW OrderDetails AS
SELECT O.OrderID, O.OrderDate, O.CustomerID, C.CustomerSurname, C.CustomerForename, C.CompanyName, OD.TyreID, T.TyreDesc,  TT.TyreTypeDesc, T.TyrePrice, OD.Quantity, T.TyrePrice * OD.Quantity AS Subtotal  
FROM Customer C
JOIN [Order] O ON O.CustomerID = C.CustomerID
JOIN OrderDetail OD ON OD.ORDERID = O.OrderID
JOIN Tyre T ON T.TyreID = OD.TyreID
JOIN TyreType TT ON TT.TyreTypeCode = T.TyreTypeCode;
