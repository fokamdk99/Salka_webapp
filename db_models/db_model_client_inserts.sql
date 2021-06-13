insert into Cities (Name) values ('Warszawa');
insert into Cities (Name) values ('Poznan');
insert into Cities (Name) values ('Gdansk');

insert into Posts (PostalCode) values ('01-930');
insert into Posts (PostalCode) values ('22-476');
insert into Posts (PostalCode) values ('01-941');
insert into Posts (PostalCode) values ('12-422');

insert into Addresses (Street, CityId, HouseNumber, FlatNumber, PostId) values ('Swietokrzyska', 1, 64, 23, 1);
insert into Addresses (Street, CityId, HouseNumber, FlatNumber, PostId) values ('Wiatraczna', 2, 128, 18, 2);
insert into Addresses (Street, CityId, HouseNumber, FlatNumber, PostId) values ('Konski Jar', 1, 6, 1, 3);
insert into Addresses (Street, CityId, HouseNumber, FlatNumber, PostId) values ('Dluga', 3, 43, 17, 4);

insert into RecordingStudios(Name, AddressId) values ('Rexast', 3);

insert into Clients (Bandname, PhoneNumber, Email, RecordingStudioId, AddressId) values ('The Ksztaut', '123456789', 'stas@wp.pl', 1, 4);
insert into Clients (Bandname, PhoneNumber, Email, RecordingStudioId, AddressId) values ('Najarani', '987654321', 'kuba@wp.pl', 1, 2);

insert into Staff (Name, Surname, AddressId, RecordingStudioId) values ('Rafal', 'Gorecki', 1, 1);

select * from Cities;
select * from Posts;
select * from Addresses;
select * from RecordingStudios;
select * from Clients;
select * from Staff;

