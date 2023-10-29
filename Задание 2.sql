SELECT Product.Name, Category.Name
FROM Product
LEFT JOIN ProductCategory ON Product.ID = ProductCategory.ProductID
LEFT JOIN Category ON ProductCategory.CategoryID = Category.ID