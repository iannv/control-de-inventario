SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, C.Descripcion AS Categoria, M.Descripcion AS Marca, A.Precio FROM ARTICULOS AS A, CATEGORIAS AS C, MARCAS AS M WHERE A.IdCategoria = C.Id AND A.IdMarca = M.Id

INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, ImagenUrl, IdCategoria, IdMarca, Precio) VALUES ('J89', 'Poco x6 Pro', 'De alto rendimiento', '', 1, 1, 890000)

UPDATE ARTICULOS SET ImagenUrl = 'https://www.tecstudio.com.br/wp-content/uploads/2024/01/poco-x6-live2.jpg' WHERE Id = 6


SELECT Id, Descripcion FROM CATEGORIAS
SELECT Id, Descripcion FROM MARCAS