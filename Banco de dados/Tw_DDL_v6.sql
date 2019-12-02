CREATE DATABASE Tw;
USE Tw;
CREATE TABLE USUARIO(
	id_usuario INT IDENTITY PRIMARY KEY NOT NULL,
	nome_completo VARCHAR(100) NOT NULL,
	nome_usuario VARCHAR(50) NOT NULL,
	email VARCHAR(255) NOT NULL,
	senha VARCHAR(255) NOT NULL,
	imagem_usuario VARCHAR(255),
	status_usuario BIT DEFAULT(1),
	categoria_usuario BIT DEFAULT(1)
);
CREATE TABLE CATEGORIA(
	id_categoria INT IDENTITY PRIMARY KEY NOT NULL,
	nome_categoria VARCHAR(50) NOT NULL,
	status_categoria BIT DEFAULT(1)
);
CREATE TABLE EQUIPAMENTO(
	id_equipamento INT IDENTITY PRIMARY KEY NOT NULL,
	nome_equipamento VARCHAR(50) NOT NULL,
	marca VARCHAR(50) NOT NULL,
	modelo VARCHAR(50),
	sistema_operacional VARCHAR(50),
	polegada VARCHAR(50),
	processador VARCHAR(50),
	memoria_ram VARCHAR(50),
	ssd VARCHAR(50),
	hd VARCHAR(50),
	placa_de_video VARCHAR(50),
	alimentacao VARCHAR(50),
	peso VARCHAR(50),
	dimensoes VARCHAR(50),
	status_equipamento BIT DEFAULT(1),
	id_categoria INT FOREIGN KEY REFERENCES CATEGORIA(id_categoria)
);
CREATE TABLE CLASSIFICADO(
	id_classificado INT IDENTITY PRIMARY KEY NOT NULL,
	codigo_classificado INT,
	preco MONEY NOT NULL,
	numero_de_serie VARCHAR(60) NOT NULL,
	avaliacao TEXT NOT NULL,
	fim_de_vida_util DATE NOT NULL,
	data_fabricacao DATE NOT NULL,
	softwares_inclusos TEXT,
	status_classificado BIT DEFAULT(1),
	id_equipamento INT FOREIGN KEY REFERENCES EQUIPAMENTO(id_equipamento)
);
CREATE TABLE IMAGEMCLASSIFICADO(
	id_imagem_classificado INT IDENTITY PRIMARY KEY NOT NULL,
	imagem VARCHAR(255),
	id_classificado INT FOREIGN KEY REFERENCES CLASSIFICADO(id_classificado)
);

CREATE TABLE INTERESSE(
	id_interesse INT IDENTITY PRIMARY KEY NOT NULL,
	status_interesse BIT DEFAULT(1),
	comprador BIT DEFAULT(0),
	data_compra DATETIME,
	data_interesse DATETIME DEFAULT GETDATE(),
	id_classificado INT FOREIGN KEY REFERENCES CLASSIFICADO(id_classificado),
	id_usuario INT FOREIGN KEY REFERENCES USUARIO(id_usuario)
);
