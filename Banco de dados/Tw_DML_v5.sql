 USE Tw;
INSERT INTO USUARIO(nome_completo,nome_usuario,email,senha, imagem_usuario)
VALUES ('Marcela Bezerra de Louca', 'Marcela', 'marcela@thoughtworks.com', '12345qwer', 'C://'),
	   ('Denilson Alves Cabral', 'Denilson', 'desilson@thoughtworks.com', '21345qwer','C://'),
	   ('Lucas Simplicio de Souza', 'Lucas', 'lucas@thoughtworks.com', '31245qwer', 'C://'),
	   ('Victor Costa Brito', 'Victor', 'victor@thoughtworks.com', '41235qwer', 'C://');
	   
INSERT INTO CATEGORIA(nome_categoria)
VALUES ('Notebook'),
	   ('Desktop');

INSERT INTO EQUIPAMENTO(nome_equipamento,marca,modelo,sistema_operacional,polegada,processador,memoria_ram,ssd,hd,placa_de_video,alimentacao,peso,dimensoes,id_categoria)
VALUES ('MacBookPro','APPLE','MUHP2','MacOS','13.3"', 'Intel core i5','8GB RAM', '256GB','Não Possui','Intel Iris Plus Graphics 640','Bivolt','2,3kg','32,9x6,9x23,8cm',2),
	   ('INSPIRON 15','DELL','P61F','Windows 10','15.6"','Intel core i5','8GB RAM','Não possui','1TB','Nvidia GeForce MX 150','Bivolt','1,9kg','36,4x24,8x1,8cm',1),
	   ('INSPIRON 14','DELL','L14-5480-A20S','Windows 10','14"','Intel core i3','4GB RAM','128GB','Não Possui','Intel HD Graphics 620','Bivolt','1,66kg','1,9x33,9x24,19cm',1),
	   ('MacBooKAir','APPLE','MQD32BZ/A','MacOS','13.3"','Intel core i5','8GB RAM','128GB','Não Possui','Intel HD Graphics 6000','Bivolt','1,3kg','32,5x1,7x22,7cm',2);

INSERT INTO IMAGEMCLASSIFICADO(imagem_principal,imagem_sec1,imagem_sec2,imagem_sec3)
VALUES ('C://','','',''),
	   ('C://','','',''),
	   ('C://','','',''),
	   ('C://','','','');


INSERT INTO CLASSIFICADO(codigo_classificado, preco, numero_de_serie, avaliacao, fim_de_vida_util, data_fabricacao,softwares_inclusos,id_imagem_classificado,id_equipamento)
VALUES ('00000001','8000.56','11111XXX245','BOM ESTADO','29/05/2019','29/05/2016','Fotos,IMove,GarageBand',1,1),
	   ('00000002','4356.78','22222XXX246','BOM ESTADO','28/04/2019','28/04/2016','Microsoft Office Trial',2,3),
	   ('00000003','1346.45','33333XXX247','BATERIA VICIADA','04/02/2016','04/02/2013','Microsoft Office Trial',3,2),
	   ('00000004','14563.13','44444XXX248','BOM ESTADO','16/06/2017','16/06/2014','Pages,Numbers,Keynote',4,4);

INSERT INTO INTERESSE(id_classificado,id_usuario)
VALUES (1,3),
	   (4,4),
	   (4,2),
	   (1,1);
