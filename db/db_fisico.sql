
-- -----------------------------------------------------
-- Schema test_trainee
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `test_trainee` DEFAULT CHARACTER SET utf8 ;
USE `test_trainee` ;

-- -----------------------------------------------------
-- Table `test_trainee`.`Cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `test_trainee`.`Cliente` (
  `Id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(60) NOT NULL,
  `Sexo` CHAR(1) NOT NULL,
  `DataNascimento` DATE NOT NULL,
  `EstadoCivil` CHAR(1) NOT NULL,
  `CPF` CHAR(14) NOT NULL,
  `RG` CHAR(20) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `test_trainee`.`Endereco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `test_trainee`.`Endereco` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `tipo_id` INT NOT NULL,
  `Cliente_Id` INT UNSIGNED NOT NULL,
  `Logradouro` VARCHAR(80) NOT NULL,
  `Numero` INT NOT NULL,
  `bairro` VARCHAR(60) NOT NULL,
  `Complemento` VARCHAR(45) NOT NULL,
  `Cidade` VARCHAR(60) NOT NULL,
  `UF` VARCHAR(2) NOT NULL,
  `CEP` VARCHAR(8) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Endereco_Cliente_idx` (`Cliente_Id` ASC),
  CONSTRAINT `fk_Endereco_Cliente`
    FOREIGN KEY (`Cliente_Id`)
    REFERENCES `test_trainee`.`Cliente` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `test_trainee` ;

-- -----------------------------------------------------
-- procedure prc_cliente_selecionar
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
create procedure prc_cliente_selecionar()
begin 
Select a.id
,a.nome
,a.sexo
,a.datanascimento
,a.estadocivil
,a.cpf
,a.rg from Cliente a;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure prc_cliente_selecionar_id
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
create procedure prc_cliente_selecionar_id(in $cliente_id int)
begin
select a.id
,a.nome
,a.sexo
,a.datanascimento
,a.estadocivil
,a.cpf
,a.rg from cliente a where id=$cliente_id;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure prc_cliente_insert
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
create procedure prc_cliente_insert($nome varchar(60), $sexo char(1), $datanascimento date, $estadocivil char(1), $cpf char(14), $rg char(20))
begin 
insert into Cliente values(null, $nome, $sexo, $datanascimento, $estadocivil, $cpf, $rg);
select LAST_INSERT_ID();
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure prc_endereco_insert
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
create procedure prc_endereco_insert($tipo_id int,$cliente_id int, $logradouro varchar(80), $numero int, $bairro varchar(60), $complemento varchar(45), $cidade varchar(60), $uf varchar(2), $cep varchar(8))
begin 
insert into Endereco values(null, $tipo_id,$cliente_id, $logradouro, $numero, $bairro, $complemento, $cidade, $uf, $cep);
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure prc_cliente_editar_id
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
create procedure prc_cliente_editar_id($cliente_id int, $nome varchar(60), $sexo char(1), $datanascimento date, $estadocivil char(1), $cpf char(14), $rg char(20))
begin 
update Cliente set nome = ifNULL($nome, nome)
, sexo = ifNULL($sexo, sexo)
, datanascimento = ifNULL($datanascimento, datanascimento)
, estadocivil = ifNULL($estadocivil, estadocivil)
, cpf = ifNULL($cpf, cpf)
, rg = ifNULL($rg, rg) where id=$cliente_id;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure prc_endereco_editar_id
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
create procedure prc_endereco_editar_id($id int, $tipo_id int,$cliente_id int, $logradouro varchar(80), $numero int, $bairro varchar(60), $complemento varchar(45), $cidade varchar(60), $uf varchar(2), $cep varchar(8))
begin
 update Endereco set tipo_id = ifNULL($tipo_id,tipo_id) 
, cliente_id = ifNULL($cliente_id,cliente_id) 
, logradouro = ifNULL($logradouro,logradouro) 
, numero = ifNULL($numero,numero) 
, bairro = ifNULL($bairro,bairro) 
, complemento = ifNULL($complemento,complemento) 
, cidade = ifNULL($cidade,cidade) 
, uf = ifNULL($uf,uf) 
, cep = ifNULL($cep,cep) where id=$id;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure prc_cliente_filtro
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
create procedure prc_cliente_filtro($nome varchar(60), $sexo char(1), $estadocivil char(1), $cpf char(14))
begin 
SELECT * FROM cliente WHERE nome LIKE CONCAT("%",IFNULL($nome,nome),"%") and sexo=IFNULL($sexo,sexo) and estadocivil=IFNULL($estadocivil,estadocivil) and cpf=IFNULL($cpf,cpf);
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure prc_endereco_selecionar_cliente_id
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
create procedure prc_endereco_selecionar_cliente_id(in $cliente_id int)
begin 
select e.id
,e.tipo_id
,e.cliente_id
,e.logradouro
,e.numero
,e.bairro
,e.complemento
,e.cidade
,e.uf
,e.cep from endereco e where cliente_id=$cliente_id;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure prc_endereco_lista_id
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
create procedure prc_endereco_lista_id($id int)
begin 
select e.id
,e.tipo_id
,e.cliente_id
,e.logradouro
,e.numero
,e.bairro
,e.complemento
,e.cidade
,e.uf
,e.cep from endereco e WHERE e.id=$id;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure prc_cliente_delete
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
Create procedure prc_cliente_delete($id int )
begin 
DELETE FROM endereco WHERE cliente_id=$id;
DELETE FROM cliente WHERE id=$id;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure prc_endereco_delete
-- -----------------------------------------------------

DELIMITER $$
USE `test_trainee`$$
Create procedure prc_endereco_delete($id int )
begin 
DELETE FROM endereco WHERE id=$id;
end$$

DELIMITER ;
