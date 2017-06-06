create table Zaposleni(
ZaposleniID int identity(1,1) not null,
Ime nvarchar(50) not null,
Prezime nvarchar(50) not null,
JMBG int not null
)
go

create table Zahtevi (
ZahteviID int identity (1,1) not null,
ZaposleniID int not null,
OpisProblema nvarchar (100) not null,
BrojKlijenta int not null,
ResenjeProblema nvarchar (100) not null

)
go

alter table Zaposleni
add constraint PK_Zaposleni primary key (ZaposleniID)
go

alter table Zahtevi
add constraint PK_Zahtevi primary key (ZahteviID)
go
alter table Zahtevi
add constraint FK_ZaposleniZahtevi foreign key (ZaposleniID)
references Zaposleni(ZaposleniID)

create procedure insert_zaposleni(
@pIme nvarchar(50),
@pPrezime nvarchar(50),
@pJMBG int
)
as
begin
	begin transaction
		insert into Zaposleni(Ime,Prezime,JMBG)
		values(@pIme,@pPrezime,@pJMBG)
if @@ERROR <> 0
	begin
		rollback
	end
else
	begin
		commit
	end
end
go

create procedure update_zaposleni(
@pZaposleniID int,
@pIme nvarchar(50),
@pPrezime nvarchar(50),
@pJMBG int
)
as
begin
	begin transaction
		update Zaposleni
		set Ime=@pIme,Prezime=@pPrezime,JMBG=@pJMBG
		where ZaposleniID=@pZaposleniID
if @@ERROR <> 0
	begin
		rollback
	end
else
	begin
		commit
	end
end
go


create procedure delete_Zaposleni(
@pZaposleniID int
)
as
begin
	begin transaction
		delete from Zaposleni
		where ZaposleniID=@pZaposleniID
if @@ERROR <> 0
	begin
		rollback
	end
else
	begin
		commit
	end
end
go


create proc insert_zahtevi (



@pZaposleniID int,
@pOpisProblema nvarchar (100) ,
@pBrojKlijenta int ,
@pResenjeProblema nvarchar (100) 

)
as
begin
	begin transaction
		insert into Zahtevi(ZaposleniID,OpisProblema,BrojKlijenta,ResenjeProblema)
		values(@pZaposleniID,@pOpisProblema,@pBrojKlijenta,@pResenjeProblema)
if @@ERROR <> 0
	begin
		rollback
	end
else
	begin
		commit
	end
end
go
create procedure update_zahtevi(
@pZahteviID int,
@pZaposleniID int,
@pOpisProblema nvarchar (100) ,
@pBrojKlijenta int ,
@pResenjeProblema nvarchar (100)
)
as
begin
	begin transaction
		update Zahtevi
		set OpisProblema=@pOpisProblema,BrojKlijenta=@pBrojKlijenta,ResenjeProblema=@pResenjeProblema
		where ZahteviID=@pZahteviID
if @@ERROR <> 0
	begin
		rollback
	end
else
	begin
		commit
	end
end
go
create procedure delete_zahtevi(
@pZahteviID int
)
as
begin
	begin transaction
		delete from Zahtevi
		where ZahteviID=@pZahteviID
if @@ERROR <> 0
	begin
		rollback
	end
else
	begin
		commit
	end
end
go


exec insert_zaposleni N'Nikola', N'Cavic',994712727




exec insert_zahtevi 1,N'Guma je neispravna stigla vlasniku',0654322316,N'Poslali smo tehnicara da popravi'