declare @rowCount int


select @rowCount = count(*) from ObrtDetalj

if (@rowCount = 0) begin
	insert into ObrtDetalj(NazivObrta, ObrtOpis, Vlasnik, Ulica, KucniBroj, PostanskiBroj, Grad, OIB, ZiroRacun)
	values('LH PROGRAMMING', 'obrt za USLUGE', 'Zlatko Herzl', 'ULICA PLATANA', '2', '10040', 'Zagreb', '89485468009', 'HR5124840081107499065')
end

select @rowCount = count(*) from ObrtKlijent
if (@rowCount = 0) begin
	insert into ObrtKlijent(NazivKlijenta, Ulica, KucniBroj, PostanskiBroj, Grad, OIB) values('Algebra d.o.o.', 'Maksimirska', '58a', '10000', 'Zagreb', '24919984448')
	insert into ObrtKlijent(NazivKlijenta, Ulica, KucniBroj, PostanskiBroj, Grad, OIB) values('Visoko U�ili�te Algebra', 'Ilica', '212', '10000', 'Zagreb', '14575159920')
end

select @rowCount = count(*) from RacunFooter
if (@rowCount = 0) begin
	insert into RacunFooter(PdvInfo, UplataInfo) 
	values('Izdavatelj ra�una nije obveznik poreza na dodanu vrijednost sukladno �l. 90. st. 2. Zakona o porezu na dodanu vrijednost (NN 73/13).',
	 'Uplatu izvr�iti na �iro ra�un broj {0}. U rubriku poziv na broj molimo upi�ite broj ra�una.')
end


select * from ObrtDetalj
select * from ObrtKlijent
select * from RacunFooter

