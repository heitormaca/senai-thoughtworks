 USE Tw;
	 
INSERT INTO CATEGORIA(nome_categoria)
VALUES ('Notebook'),
	   ('Desktop');

INSERT INTO EQUIPAMENTO(nome_equipamento,marca,modelo,sistema_operacional,polegada,processador,memoria_ram,ssd,hd,placa_de_video,alimentacao,peso,dimensoes,id_categoria)
VALUES ('MacBookPro','APPLE','MUHP2','MacOS','13.3"', 'Intel core i5','8GB RAM', '256GB','Não Possui','Intel Iris Plus Graphics 640','Bivolt','2,3kg','32,9x6,9x23,8cm',2),
	   ('INSPIRON 15','DELL','P61F','Windows 10','15.6"','Intel core i5','8GB RAM','Não possui','1TB','Nvidia GeForce MX 150','Bivolt','1,9kg','36,4x24,8x1,8cm',1),
	   ('INSPIRON 14','DELL','L14-5480-A20S','Windows 10','14"','Intel core i3','4GB RAM','128GB','Não Possui','Intel HD Graphics 620','Bivolt','1,66kg','1,9x33,9x24,19cm',1),
	   ('MacBooKAir','APPLE','MQD32BZ/A','MacOS','13.3"','Intel core i5','8GB RAM','128GB','Não Possui','Intel HD Graphics 6000','Bivolt','1,3kg','32,5x1,7x22,7cm',2);
