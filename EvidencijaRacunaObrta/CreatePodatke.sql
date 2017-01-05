declare @rowCount int


select @rowCount = count(*) from ObrtDetalj

if (@rowCount = 0) begin
	insert into ObrtDetalj(NazivObrta, ObrtOpis, Vlasnik, Ulica, KucniBroj, PostanskiBroj, Grad, OIB, ZiroRacun)
	values('LH PROGRAMMING', 'obrt za USLUGE', 'Zlatko Herzl', 'ULICA PLATANA', '2', '10040', 'Zagreb', '89485468009', 'HR5124840081107499065')
end

select @rowCount = count(*) from ObrtKlijent
if (@rowCount = 0) begin
	insert into ObrtKlijent(NazivKlijenta, Ulica, KucniBroj, PostanskiBroj, Grad, OIB) values('Algebra d.o.o.', 'Maksimirska', '58a', '10000', 'Zagreb', '24919984448')
	insert into ObrtKlijent(NazivKlijenta, Ulica, KucniBroj, PostanskiBroj, Grad, OIB) values('Visoko Uèilište Algebra', 'Ilica', '212', '10000', 'Zagreb', '14575159920')
end

select @rowCount = count(*) from RacunFooter
if (@rowCount = 0) begin
	insert into RacunFooter(PdvInfo, UplataInfo) 
	values('Izdavatelj raèuna nije obveznik poreza na dodanu vrijednost sukladno èl. 90. st. 2. Zakona o porezu na dodanu vrijednost (NN 73/13).',
	 'Uplatu izvršiti na žiro raèun broj {0}. U rubriku poziv na broj molimo upišite broj raèuna.')
end


select * from ObrtDetalj
select * from ObrtKlijent
select * from RacunFooter

