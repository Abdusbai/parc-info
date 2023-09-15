create database Gestion_Pac_Informatique
go
use Gestion_Pac_Informatique
go
create table Entite(
	LocalisationEn nvarchar(08) primary key,
	DirectionEn nvarchar(250),
	DivisionEn nvarchar(250),
	ServiceEn nvarchar(250),
	AbreviationEn nvarchar(30)
)
go
insert into Entite values
--Ministre
('10000','Cabinet','','','Cabinet'),
('10010','Inspection G�n�rale','','','IG'),
('10020','Secr�taire G�n�ral','','','SG'),
-- La Direction des Affaires Administratives et Juridiques
('10030','Direction des Affaires Administratives et Juridiques','','','DAAJ'),
('10040','Direction des Affaires Administratives et Juridiques','Achats','Achats','DAAJ/DA/DA'),
('10050','Direction des Affaires Administratives et Juridiques','Achats','Programation et normalisation des achats','DAAJ/DA/PNA'),
('10060','Direction des Affaires Administratives et Juridiques','Logistique et patrimoine','Inventaire et �quipement','DAAJ/LP/IE'),
('10070','Direction des Affaires Administratives et Juridiques','Logistique et patrimoine','Constructions et Maintenances','DAAJ/LP/CM'),
('10080','Direction des Affaires Administratives et Juridiques','Logistique et patrimoine','Support et Pac auto','DAAJ/LP/SPA'),
('10090','Direction des Affaires Administratives et Juridiques','Contentieux','Autre contentieux','DAAJ/C/AC'),
('10100','Direction des Affaires Administratives et Juridiques','Contentieux','Contentieux relatifs au personnel','DAAJ/C/CRP'),
('10110','Direction des Affaires Administratives et Juridiques','Service du contr�le interne des achats','','DAAJ/SCIA'),
('10120','Direction des Affaires Administratives et Juridiques','L�gislation et �tudes juridiques','R�forme des structures fonci�res agricoles','DAAJ/LEJ/RSFA'),
('10130','Direction des Affaires Administratives et Juridiques','L�gislation et �tudes juridiques','Affaires juridiques','DAAJ/LEJ/AJ'),
('10140','Direction des Affaires Administratives et Juridiques','L�gislation et �tudes juridiques','Accords internationaux','DAAJ/LEJ/AI'),
('10150','Direction des Affaires Administratives et Juridiques','L�gislation et �tudes juridiques','Etudes des contrats','DAAJ/LEJ/EC'),
('10160','Direction des Affaires Administratives et Juridiques','Contentieux','Autre contentieux','DAAJ/C/AC'),
('10170','Direction des Affaires Administratives et Juridiques','Contentieux','Contentieux relatifs au personnel','DAAJ/C/CRP'),
-- La Direction de D�veloppement des Fili�res de Production
('10180','Direction de D�veloppement des Fili�res de Production','','','DDFP'),
('10190','Direction de D�veloppement des Fili�res de Production','Produits du Terroir','Relations avec les acteurs','DDFP/PT/RA'),
('10200','Direction de D�veloppement des Fili�res de Production','Produits du Terroir','Planification et pilotage des plans de d�veloppement','DDFP/PT/PPPD'),
('10210','Direction de D�veloppement des Fili�res de Production','Produits du Terroir','R�gulation et serveillance des march�s','DDFP/PT/RSM'),
('10220','Direction de D�veloppement des Fili�res de Production','Agrobusiness','Relations avec les acteurs','DDFP/A/RA'),
('10230','Direction de D�veloppement des Fili�res de Production','Agrobusiness','D�veloppement des agropotes','DDFP/A/DA'),
('10240','Direction de D�veloppement des Fili�res de Production','Labellisation','Promotion des labels','DDFP/L/PL'),
('10250','Direction de D�veloppement des Fili�res de Production','Labellisation','Commission de la labellisation','DDFP/L/CL'),
('10260','Direction de D�veloppement des Fili�res de Production','Fili�re v�g�tale','Relations avec les acteurs','DDFP/FV/RA'),
('10270','Direction de D�veloppement des Fili�res de Production','Fili�re v�g�tale','R�gulation et serveillance des march�s','DDFP/FV/RSM'),
('10280','Direction de D�veloppement des Fili�res de Production','Fili�re v�g�tale','Planification et pilotage des plans de d�veloppement','DDFP/FV/PPPD'),
('10290','Direction de D�veloppement des Fili�res de Production','Fili�re Animale','Relations avec les acteurs','DDFP/FA/RA'),
('10300','Direction de D�veloppement des Fili�res de Production','Fili�re Animale','R�gulation et serveillance des march�s','DDFP/FA/RSM'),
('10310','Direction de D�veloppement des Fili�res de Production','Fili�re Animale','Planification et pilotage des plans de plans de d�veloppements','DDFP/FA/PPPPD'),
-- La Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole
('10320','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','','','DIAEA'),
('10330','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','Promotion et r�gulation des PPP en irrigation','Suivi et regulation des PPP','DIAEA/PRPPPI/SPPP'),
('10340','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','Promotion et r�gulation des PPP en irrigation','Promotion et mise en place des PPP','DIAEA/PRPPPI/PMPPPP'),
('10350','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','Am�nagements fonciers et am�nagements des parcours','Planification et suivi des am�nagements fonci�res','DIAEA/AFAP/PSAF'),
('10360','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','Am�nagements fonciers et am�nagements des parcours','Planification et suivi des am�nagements des parcours','DIAEA/AFAP/PSAP'),
('10370','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','Am�nagements Hydro agricoles','Les grands projets','DIAEA/AHA/GP'),
('10380','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','Am�nagements Hydro agricoles','Planification et suivi des am�nagements Hydro agricoles','DIAEA/AHA/PSAHA'),
('10390','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','Ressources Hydro agricoles','Promotion de l''�conomie de l''eau','DIAEA/RHS/PEE'),
('10400','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','Ressources Hydro agricoles','Planification et suivi des ressources Hydro agricoles','DIAEA/RHS/PSRHA'),
('10410','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','Ressources Hydro agricoles','Gestion de l''irrigation','DIAEA/RHS/GI'),
('10420','Direction de l�Irrigation et de l�Am�nagement de l�Espace Agricole','Ressources Hydro agricoles','Essais, exp�rimentations et normalisation','DIAEA/RHS/EEN'),
-- La Direction du D�veloppement de l�Espace Rural et des Zones de Montagne
('10430','Direction du D�veloppement de l�Espace Rural et des Zones de Montagne','','','DDERZM'),
('10440','Direction du D�veloppement de l�Espace Rural et des Zones de Montagne','Division de Coordination et d''�valuation','Servise de Suivre et d''Evaluation','DDERZM/DCE/SSE'),
('10450','Direction du D�veloppement de l�Espace Rural et des Zones de Montagne','Division de Coordination et d''�valuation','Service de Pilotage de Coordination','DDERZM/DCE/SPC'),
('10460','Direction du D�veloppement de l�Espace Rural et des Zones de Montagne','Division D''Ing�n�rie	de Projets','Service de Partenariats','DDERZM/DIP/SP'),
('10470','Direction du D�veloppement de l�Espace Rural et des Zones de Montagne','Division D''Ing�n�rie	de Projets','Service de l''Ing�n�rie et Montage de Projets','DDERZM/DIP/SIMP'),
('10480','Direction du D�veloppement de l�Espace Rural et des Zones de Montagne','Division D''Ing�n�rie	de Projets','Service d''Appele � projets','DDERZM/DIP/SAP'),
-- La Direction de l�Enseignement, de la Formation et de la Recherche
('10490','Direction de l�Enseignement, de la Formation et de la Recherche','','','DEFR'),
('10500','Direction de l�Enseignement, de la Formation et de la Recherche','Vulgarisation','Suivi et r�gulation','DEFR/V/SR'),
('10510','Direction de l�Enseignement, de la Formation et de la Recherche','Vulgarisation','Planification et pilotage','DEFR/V/PP'),
('10520','Direction de l�Enseignement, de la Formation et de la Recherche','Enseignement technique et formation professionelle','Lyc�e agricoles','DEFR/ETFP/LA'),
('10530','Direction de l�Enseignement, de la Formation et de la Recherche','Enseignement technique et formation professionelle','Planification et coordination des �tablissements','DEFR/ETFP/PCE'),
('10540','Direction de l�Enseignement, de la Formation et de la Recherche','Enseignement sup�rieur et R&D','R&D','DEFR/ESR&D/R&D'),
('10550','Direction de l�Enseignement, de la Formation et de la Recherche','Enseignement sup�rieur et R&D','Enseignement sup�rieur','DEFR/ESR&D/ES'),
-- Direction Financi�re
('10560','Direction Financi�re','','','DF'),
('10570','Direction Financi�re','Cont�le de gestion','Contr�le de gestion financi�re','DF/CG/CGF'),
('10580','Direction Financi�re','Cont�le de gestion','Contr�le de gestion op�rationnel','DF/CG/CGO'),
('10590','Direction Financi�re','Financements','Ing�nierie financi�re des projets','DF/F/IFP'),
('10600','Direction Financi�re','Financements','Gestion des assurances agricoles','DF/F/GAA'),
('10610','Direction Financi�re','Financements','Financements','DF/F/F'),
('10620','Direction Financi�re','Etablissements publics et participations','Gestion des contrats programmses','DF/EPP/GCP'),
('10630','Direction Financi�re','Etablissements publics et participations','Etablissements publics et participations','DF/EPP/EPP'),
('10640','Direction Financi�re','Aides et Incitations','Coordination et appui','DF/AI/CA'),
('10650','Direction Financi�re','Aides et Incitations','Suivi et pilotage','DF/AI/SV'),
('10660','Direction Financi�re','Aides et Incitations','Planification et Programmation','DF/AI/PP'),
('10670','Direction Financi�re','Gestion financi�re','Gestion budg�taire','DF/GF/GB'),
('10680','Direction Financi�re','Gestion financi�re','Programmation budg�taire','DF/GF/PB'),
('10690','Direction Financi�re','Gestion financi�re','Comptabilit�','DF/GF/C'),
-- La Direction des Syst�mes d�Information
('10700','Direction des Syst�mes d�Information','','','DSI'),
('10710','Direction des Syst�mes d�Information','Division Organisation','Organisation du travail','DSI/DO/OT'),
('10720','Direction des Syst�mes d�Information','Division Organisation','Proc�dures','DSI/DO/P'),
('10730','Direction des Syst�mes d�Information','Division Gestion des SI de l''Administration Centrale','Exploitations du SI','DSI/DGSIAC/ESI'),
('10740','Direction des Syst�mes d�Information','Division Gestion des SI de l''Administration Centrale','Assistance aux utilisateurs','DSI/DGSIAC/AU'),
('10750','Direction des Syst�mes d�Information','Division d�veloppement des SI','Approvisionnement informatique','DSI/DDSI/AI'),
('10760','Direction des Syst�mes d�Information','Division d�veloppement des SI','D�veloppement des SI','DSI/DGSIAC/DSI'),
('10770','Direction des Syst�mes d�Information','','Service s�curit� des syst�mes d''information','DSI/SSSI'),
--La Direction des Ressources Humaines
('10780','Direction des Ressources Humaines','','','DRH'),
('10790','Direction des Ressources Humaines','Actions sociales','Relations avec les partenaires sociaux','DRH/AS/RPS'),
('10800','Direction des Ressources Humaines','Actions sociales','Oeuvres sociales','DRH/AS/OS'),
('10810','Direction des Ressources Humaines','Gestion des administrative RH','Gestion administrative du personnel des autres statuts','DRH/GARH/GAPAS'),
('10820','Direction des Ressources Humaines','Gestion des administrative RH','Gestion administrative du personnel de la fonction publique','DRH/GARH/GAPFP'),
('10830','Direction des Ressources Humaines','Gestion des administrative RH','Gestion des d�pendenses du personnel','DRH/GARH/GDP'),
('10840','Direction des Ressources Humaines','D�veloppement des RH','Aptitudes professionnelles et carri�res','DRH/DRH/APC'),
('10850','Direction des Ressources Humaines','D�veloppement des RH','Gestion pr�visionnelle des RH','DRH/DRH/GPRH'),
('10860','Direction des Ressources Humaines','D�veloppement des RH','Formation continue','DRH/DRH/FC'),
--La Direction de la Strat�gie et des Statistiques
('10870','Direction de la Strat�gie et des Statistiques','','','DSS'),
('10880','Direction de la Strat�gie et des Statistiques','D�veloppement des march�s','March� du continent am�ricain','DTSS/DM/MCA'),
('10890','Direction de la Strat�gie et des Statistiques','D�veloppement des march�s','March� domestique','DSTS/DM/MD'),
('10900','Direction de la Strat�gie et des Statistiques','D�veloppement des march�s','Autres march�s','DSTS/DM/AM'),
('10910','Direction de la Strat�gie et des Statistiques','D�veloppement des march�s','March� Europ�en','DSTS/DM/ME'),
('10920','Direction de la Strat�gie et des Statistiques','Coop�ration','Coop�ration multilat�rale','DSS/C/CM'),
('10930','Direction de la Strat�gie et des Statistiques','D�veloppement des march�s','Coop�ration bilat�rale','DSTS/C/CB'),
('10940','Direction de la Strat�gie et des Statistiques','Statiqtiques','Statiqtiques de la fili�re v�g�tale','DSTS/S/SFV'),
('10950','Direction de la Strat�gie et des Statistiques','Statiqtiques','Statiqtiques de la fili�re animale','DSTS/S/SFA'),
('10960','Direction de la Strat�gie et des Statistiques','Statiqtiques','Enqu�tes et recensement','DSS/S/ER'),
('10970','Direction de la Strat�gie et des Statistiques','Statiqtiques','Strat�gie des facteurs transversaux','DSTS/S/SFT'),
('10980','Direction de la Strat�gie et des Statistiques','Strat�gie','Strat�gie de la fili�re v�g�tale','DSTS/ST/STFV'),
('10990','Direction de la Strat�gie et des Statistiques','Strat�gie','Strat�gie de la fili�re animale','DSTS/ST/STFA'),
('11000','Direction de la Strat�gie et des Statistiques','Strat�gie','Strat�gie des aides et des incitations','DSTS/ST/STAI'),
('11010','Direction de la Strat�gie et des Statistiques','Strat�gie','Strat�gie des facteurs transversaux','DSTS/ST/STFT')
go
create table Fonction(
	CodeFo int primary key identity(1,1),
	DescFo nvarchar(100)
)
go
insert into Fonction values
('Agent de Bureau'),
('N�ant'),
('Chef de Service'),
('Charg� de Mission (Cabinet)'),
('Ing�nieur'),
('Cadre'),
('Technicien'),
('Administrateur'),
('Directeur'),
('Helpdesk')
go 
create table Personnel(
	DrppPerso nvarchar(10) primary key,
	CinPerso nvarchar(20) unique,
	NomPerso nvarchar(40),
	PrenomPerso nvarchar(40),
	DateNePerso nvarchar(15),
	DateRecPerso nvarchar(15),
	CodeFo int foreign key references Fonction(CodeFo) on delete cascade on update cascade,
	NumBurPerso nvarchar(10),
	TeleBurPerso nvarchar(20),
	GsmPerso nvarchar(20),
	EmailPerso nvarchar(30),
	SitePerso nvarchar(30),
	BatimentPerso nvarchar(30),
	ActifPerso nvarchar(10),
	LocalisationEn nvarchar(08) foreign key references Entite(LocalisationEn) on delete cascade on update cascade
)
go
create table Categorie(
	CodeCat int primary key identity(1,1),
	DescCat nvarchar(50)
)

go
insert into Categorie values
('Ecran'),
('Imprimante'),
('Pc Portable'),
('Projecteur'),
('Scanner'),
('Unit� Centrale')
go

create table Marque(
	CodeMar int primary key identity(1,1),
	DescMar nvarchar(50)
)
go
insert into Marque values
('DELL'),
('HP'),
('LENOVO'),
('HP COMPAQ')
go
create table Materiel(
	NumSerMat nvarchar(50) primary key,
	CodeCat int foreign key references Categorie(CodeCat) on delete cascade on update cascade,
	CodeMar int foreign key references Marque(CodeMar) on delete cascade on update cascade,
	NumInvMat nvarchar(50),
	DesignMat nvarchar(250),
	ReferMat  nvarchar(250),
	DrppPerso nvarchar(10) foreign key references Personnel(DrppPerso) on delete cascade on update cascade,
)
go
create table Logiciel(
	NumLogic nvarchar(30) primary key,
	NomLogic nvarchar(50),
	NomCompag nvarchar(50),
	VersionLogic nvarchar(20),
	DrppPerso nvarchar(10) foreign key references Personnel(DrppPerso) on delete cascade on update cascade,
)
go
create table Contacte(
	CodCont int primary key identity(1,1),
	TypeCont nvarchar(50)
)
go

insert into Contacte values
('Applicatif'),
('E-Mail'),
('T�l�phone')
go
create table Probleme(
	CodProb int primary key identity(1,1),
	TypeProb nvarchar(50)
)
go

create table Ticket(
	CodeTicket int primary key identity(1,1),
	CodProb int foreign key references Probleme(CodProb) on delete cascade on update cascade,
	CodCont int foreign key references Contacte(CodCont) on delete cascade on update cascade,
	DateTicket nvarchar(15),
	HeureTicket nvarchar(15),
	DescTicket nvarchar(250),
	NumSerMat nvarchar(50) foreign key references Materiel(NumSerMat) on delete cascade on update cascade,
	NumLogi nvarchar(30) foreign key references Logiciel(NumLogic) on delete no action on update no action,
	EtatTicket nvarchar(10)
)
go
create table Suite_a_donner(
	CodeSd int primary key identity(1,1),
	DescSd nvarchar(50)
)
go
insert into Suite_a_donner values
('Non r�solu'),
('A transf�rer'),

('Diff�r�'),

('R�solu')

go
create table Service_de_transfert(
	CodeServ nvarchar(20) primary key,
	NomServ nvarchar(30),
	DrppPerso nvarchar(10) foreign key references Personnel(DrppPerso) on delete cascade on update cascade,	
)
go
create table Technicien(
	CinTech nvarchar(20) primary key,
	NomTech nvarchar(40),
	PrenomTech nvarchar(40),
	DateNeTech nvarchar(15),
	DateRecTech nvarchar(15),
	NumBurTech nvarchar(10),
	TeleBurTech nvarchar(20),
	GsmTech nvarchar(20),
	EmailTech nvarchar(30),
)
go
create table Intervention(
	NumInter int primary key identity(1,1),
	DateInter nvarchar(15),
	HeureInter nvarchar(15),
	DescInter nvarchar(200),
	CodeTicket int foreign key references Ticket(CodeTicket) on delete cascade on update cascade,	
	CinTech nvarchar(20) foreign key references Technicien(CinTech) on delete cascade on update cascade,	
	DateAffectTech nvarchar(15),
	HeureAffectTech nvarchar(15),
	CodeSd int foreign key references Suite_a_donner(CodeSd) on delete cascade on update cascade,	
	DateSd nvarchar(15),
	HeureSd nvarchar(15),
	DescSd nvarchar(250),
	CodeServ nvarchar(20) foreign key references Service_de_transfert(CodeServ) on delete no action on update no action,
	DateServ nvarchar(15),
	HeureServ nvarchar(15),
	DescServ nvarchar(250),
	DateRetourServ nvarchar(15),
	HeureRetourServ nvarchar(15),
	CinTechReaff nvarchar(20) foreign key references Technicien(CinTech) on delete no action on update no action,
	DateReaff nvarchar(15),
	HeureReaff nvarchar(15),
	DateColutre nvarchar(15),
	HeureColutre nvarchar(15),
	DescColutre nvarchar(250),
	EtatInter nvarchar(10)
)
go
create table Utilisateur(
	CinUser nvarchar(30) primary key,
	MotDePasse nvarchar(30),
	NomUser nvarchar(30),
	PrenomUser nvarchar(30),
	RoleUser nvarchar(30),
	etat_Compte nvarchar(10)
)
