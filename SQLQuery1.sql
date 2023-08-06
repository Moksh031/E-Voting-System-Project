Select * from voters

Select * from candidate

Select Name from candidate where electionsname='Punjab'
update candidate set votes_count=2 where Name='0111'
delete electionsname where name in('Jammu And Kashmir','Himachal Pradesh')
select Name from candidate where votes_count=(select max(votes_count) from candidate)