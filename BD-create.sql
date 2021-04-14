--create database CtrlFinan 

use CtrlFinan

Create Table Receita 
(	Idreceita int identity (1,1)  primary key,
	nomereceta varchar(180) not null	
)

Create Table Despesa
(
	Iddespesa int not null primary key,
	nomedespesa varchar(180) not null
)


drop table  Mov_Receita

Create table Mov_Receita
(
	Idmovreceita int identity (1,1) primary key,
	Id_mv_receita int not null,
	data_mov_receita date,
	valor_rec	decimal,
	desc_receita varchar (180)
	
)

drop table  Mov_Despesa

Create table Mov_Despesa
(
	Idmovdespesa int identity (1,1) primary key,
	Id_mv_despesa int,
	data_mov_despesa date,
	valor_des	decimal,
	desc_despesa varchar(180)
)

select * from Mov_Receita
 
 Insert into Mov_Receita values ( 1, '2021/02/01', 'Investimentos');

 Insert into  Mov_Receita  values ( 1,'2021/02/01 00:00:00', 'Teste')
 Insert into  Mov_Receita  values (1, 1,'2021-02-01 00:00:00', 'Tete2')
 Insert into  Mov_Receita  values (3,'2021-01-02 00:00:00', 2000, 'Teste')

drop table Mov_Receita

insert into Receita values  ('Extra')
delete from Receita
Select * from Receita where Idreceita = 1
