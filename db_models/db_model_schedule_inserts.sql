insert into Schedules (Name) values ('Rexast_terminarz');

insert into ReservationTypes (Type, IsProducerRequired) values ('nagranie', 1);
insert into ReservationTypes (Type, IsProducerRequired) values ('proba', 0);
insert into ReservationTypes (Type, IsProducerRequired) values ('nagrywana proba', 1);

insert into Reservations (IsPaymentCompleted, IsAcknowledged, IsRegular, TotalCost, Comment, NumberOfVocals, ClientId, ReservationTypeId, StaffId) 
values (0, 0, 0, 50, 'prosba o dodatkowy pasek do gitary', 3, 1, 2, 1);

insert into ReservationDates (Date, Start, End, ScheduleId, ReservationId) values (sysdate(), sysdate(), date_add(sysdate(), INTERVAL 1 hour), 1, 1);

select * from Schedules;
select * from ReservationTypes;
select * from Reservations;
select * from ReservationDates;