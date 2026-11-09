set @id = 566;
set @new_parentId = 571;
set @new_name = 'aaaaa';
set @data = '{}';


select 
	g.GeoLocation_ParentId, g.GeoLocation_Ids, 	g.GeoLocation_Name, g.GeoLocation_Names, p.GeoLocation_Name
into @old_ParentId, @old_Ids, @old_name, @old_names, @old_ParentName
from global_db.geolocations g
	left join global_db.geolocations p on p.GeoLocation_Id = g.GeoLocation_ParentId 
where g.GeoLocation_Id = @id;
-- select @id, @old_ParentId, @old_Ids, @old_name, @old.names, @old_ParentName;

with 
t as (
	select
		g.GeoLocation_Id Id,
		g.GeoLocation_ParentId ParentId,
		g.GeoLocation_Ids Ids,
		g.GeoLocation_Name Name,
		g.GeoLocation_Names Names 
	from global_db.geolocations g 
	where FIND_IN_SET(@id, g.GeoLocation_Ids)
)
select 
	t.Id Id, 
	t.ParentId old_ParentId, t.Ids old_Ids,
	@new_parentId new_ParenId, TRIM(both ',' from replace(CONCAT(',',Ids,','), CONCAT(',',@old_parentId,','),CONCAT(',',@new_parentId,','))) new_Ids,
	@old_name, @old_names,
	@new_name, TRIM(both ' / ' from replace(CONCAT(' / ',Names,' / '), CONCAT(' / ',@old_name,' / '),CONCAT(' / ',@new_name,' / '))) new_Names
from t;
