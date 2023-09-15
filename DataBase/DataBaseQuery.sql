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
('10010','Inspection Générale','','','IG'),
('10020','Secrétaire Général','','','SG'),
-- La Direction des Affaires Administratives et Juridiques
('10030','Direction des Affaires Administratives et Juridiques','','','DAAJ'),
('10040','Direction des Affaires Administratives et Juridiques','Achats','Achats','DAAJ/DA/DA'),
('10050','Direction des Affaires Administratives et Juridiques','Achats','Programation et normalisation des achats','DAAJ/DA/PNA'),
('10060','Direction des Affaires Administratives et Juridiques','Logistique et patrimoine','Inventaire et équipement','DAAJ/LP/IE'),
('10070','Direction des Affaires Administratives et Juridiques','Logistique et patrimoine','Constructions et Maintenances','DAAJ/LP/CM'),
('10080','Direction des Affaires Administratives et Juridiques','Logistique et patrimoine','Support et Pac auto','DAAJ/LP/SPA'),
('10090','Direction des Affaires Administratives et Juridiques','Contentieux','Autre contentieux','DAAJ/C/AC'),
('10100','Direction des Affaires Administratives et Juridiques','Contentieux','Contentieux relatifs au personnel','DAAJ/C/CRP'),
('10110','Direction des Affaires Administratives et Juridiques','Service du contrôle interne des achats','','DAAJ/SCIA'),
('10120','Direction des Affaires Administratives et Juridiques','Législation et études juridiques','Réforme des structures fonciéres agricoles','DAAJ/LEJ/RSFA'),
('10130','Direction des Affaires Administratives et Juridiques','Législation et études juridiques','Affaires juridiques','DAAJ/LEJ/AJ'),
('10140','Direction des Affaires Administratives et Juridiques','Législation et études juridiques','Accords internationaux','DAAJ/LEJ/AI'),
('10150','Direction des Affaires Administratives et Juridiques','Législation et études juridiques','Etudes des contrats','DAAJ/LEJ/EC'),
('10160','Direction des Affaires Administratives et Juridiques','Contentieux','Autre contentieux','DAAJ/C/AC'),
('10170','Direction des Affaires Administratives et Juridiques','Contentieux','Contentieux relatifs au personnel','DAAJ/C/CRP'),
-- La Direction de Développement des Filières de Production
('10180','Direction de Développement des Filières de Production','','','DDFP'),
('10190','Direction de Développement des Filières de Production','Produits du Terroir','Relations avec les acteurs','DDFP/PT/RA'),
('10200','Direction de Développement des Filières de Production','Produits du Terroir','Planification et pilotage des plans de développement','DDFP/PT/PPPD'),
('10210','Direction de Développement des Filières de Production','Produits du Terroir','Régulation et serveillance des marchés','DDFP/PT/RSM'),
('10220','Direction de Développement des Filières de Production','Agrobusiness','Relations avec les acteurs','DDFP/A/RA'),
('10230','Direction de Développement des Filières de Production','Agrobusiness','Développement des agropotes','DDFP/A/DA'),
('10240','Direction de Développement des Filières de Production','Labellisation','Promotion des labels','DDFP/L/PL'),
('10250','Direction de Développement des Filières de Production','Labellisation','Commission de la labellisation','DDFP/L/CL'),
('10260','Direction de Développement des Filières de Production','Filière végétale','Relations avec les acteurs','DDFP/FV/RA'),
('10270','Direction de Développement des Filières de Production','Filière végétale','Régulation et serveillance des marchés','DDFP/FV/RSM'),
('10280','Direction de Développement des Filières de Production','Filière végétale','Planification et pilotage des plans de développement','DDFP/FV/PPPD'),
('10290','Direction de Développement des Filières de Production','Filière Animale','Relations avec les acteurs','DDFP/FA/RA'),
('10300','Direction de Développement des Filières de Production','Filière Animale','Régulation et serveillance des marchés','DDFP/FA/RSM'),
('10310','Direction de Développement des Filières de Production','Filière Animale','Planification et pilotage des plans de plans de développements','DDFP/FA/PPPPD'),
-- La Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole
('10320','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','','','DIAEA'),
('10330','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','Promotion et régulation des PPP en irrigation','Suivi et regulation des PPP','DIAEA/PRPPPI/SPPP'),
('10340','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','Promotion et régulation des PPP en irrigation','Promotion et mise en place des PPP','DIAEA/PRPPPI/PMPPPP'),
('10350','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','Aménagements fonciers et aménagements des parcours','Planification et suivi des aménagements foncières','DIAEA/AFAP/PSAF'),
('10360','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','Aménagements fonciers et aménagements des parcours','Planification et suivi des aménagements des parcours','DIAEA/AFAP/PSAP'),
('10370','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','Aménagements Hydro agricoles','Les grands projets','DIAEA/AHA/GP'),
('10380','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','Aménagements Hydro agricoles','Planification et suivi des aménagements Hydro agricoles','DIAEA/AHA/PSAHA'),
('10390','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','Ressources Hydro agricoles','Promotion de l''économie de l''eau','DIAEA/RHS/PEE'),
('10400','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','Ressources Hydro agricoles','Planification et suivi des ressources Hydro agricoles','DIAEA/RHS/PSRHA'),
('10410','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','Ressources Hydro agricoles','Gestion de l''irrigation','DIAEA/RHS/GI'),
('10420','Direction de l’Irrigation et de l’Aménagement de l’Espace Agricole','Ressources Hydro agricoles','Essais, expérimentations et normalisation','DIAEA/RHS/EEN'),
-- La Direction du Développement de l’Espace Rural et des Zones de Montagne
('10430','Direction du Développement de l’Espace Rural et des Zones de Montagne','','','DDERZM'),
('10440','Direction du Développement de l’Espace Rural et des Zones de Montagne','Division de Coordination et d''évaluation','Servise de Suivre et d''Evaluation','DDERZM/DCE/SSE'),
('10450','Direction du Développement de l’Espace Rural et des Zones de Montagne','Division de Coordination et d''évaluation','Service de Pilotage de Coordination','DDERZM/DCE/SPC'),
('10460','Direction du Développement de l’Espace Rural et des Zones de Montagne','Division D''Ingénérie	de Projets','Service de Partenariats','DDERZM/DIP/SP'),
('10470','Direction du Développement de l’Espace Rural et des Zones de Montagne','Division D''Ingénérie	de Projets','Service de l''Ingénérie et Montage de Projets','DDERZM/DIP/SIMP'),
('10480','Direction du Développement de l’Espace Rural et des Zones de Montagne','Division D''Ingénérie	de Projets','Service d''Appele à projets','DDERZM/DIP/SAP'),
-- La Direction de l’Enseignement, de la Formation et de la Recherche
('10490','Direction de l’Enseignement, de la Formation et de la Recherche','','','DEFR'),
('10500','Direction de l’Enseignement, de la Formation et de la Recherche','Vulgarisation','Suivi et régulation','DEFR/V/SR'),
('10510','Direction de l’Enseignement, de la Formation et de la Recherche','Vulgarisation','Planification et pilotage','DEFR/V/PP'),
('10520','Direction de l’Enseignement, de la Formation et de la Recherche','Enseignement technique et formation professionelle','Lycée agricoles','DEFR/ETFP/LA'),
('10530','Direction de l’Enseignement, de la Formation et de la Recherche','Enseignement technique et formation professionelle','Planification et coordination des établissements','DEFR/ETFP/PCE'),
('10540','Direction de l’Enseignement, de la Formation et de la Recherche','Enseignement supérieur et R&D','R&D','DEFR/ESR&D/R&D'),
('10550','Direction de l’Enseignement, de la Formation et de la Recherche','Enseignement supérieur et R&D','Enseignement supérieur','DEFR/ESR&D/ES'),
-- Direction Financière
('10560','Direction Financière','','','DF'),
('10570','Direction Financière','Contôle de gestion','Contrôle de gestion financière','DF/CG/CGF'),
('10580','Direction Financière','Contôle de gestion','Contrôle de gestion opérationnel','DF/CG/CGO'),
('10590','Direction Financière','Financements','Ingénierie financière des projets','DF/F/IFP'),
('10600','Direction Financière','Financements','Gestion des assurances agricoles','DF/F/GAA'),
('10610','Direction Financière','Financements','Financements','DF/F/F'),
('10620','Direction Financière','Etablissements publics et participations','Gestion des contrats programmses','DF/EPP/GCP'),
('10630','Direction Financière','Etablissements publics et participations','Etablissements publics et participations','DF/EPP/EPP'),
('10640','Direction Financière','Aides et Incitations','Coordination et appui','DF/AI/CA'),
('10650','Direction Financière','Aides et Incitations','Suivi et pilotage','DF/AI/SV'),
('10660','Direction Financière','Aides et Incitations','Planification et Programmation','DF/AI/PP'),
('10670','Direction Financière','Gestion financière','Gestion budgétaire','DF/GF/GB'),
('10680','Direction Financière','Gestion financière','Programmation budgétaire','DF/GF/PB'),
('10690','Direction Financière','Gestion financière','Comptabilité','DF/GF/C'),
-- La Direction des Systèmes d’Information
('10700','Direction des Systèmes d’Information','','','DSI'),
('10710','Direction des Systèmes d’Information','Division Organisation','Organisation du travail','DSI/DO/OT'),
('10720','Direction des Systèmes d’Information','Division Organisation','Procédures','DSI/DO/P'),
('10730','Direction des Systèmes d’Information','Division Gestion des SI de l''Administration Centrale','Exploitations du SI','DSI/DGSIAC/ESI'),
('10740','Direction des Systèmes d’Information','Division Gestion des SI de l''Administration Centrale','Assistance aux utilisateurs','DSI/DGSIAC/AU'),
('10750','Direction des Systèmes d’Information','Division développement des SI','Approvisionnement informatique','DSI/DDSI/AI'),
('10760','Direction des Systèmes d’Information','Division développement des SI','Développement des SI','DSI/DGSIAC/DSI'),
('10770','Direction des Systèmes d’Information','','Service sécurité des systèmes d''information','DSI/SSSI'),
--La Direction des Ressources Humaines
('10780','Direction des Ressources Humaines','','','DRH'),
('10790','Direction des Ressources Humaines','Actions sociales','Relations avec les partenaires sociaux','DRH/AS/RPS'),
('10800','Direction des Ressources Humaines','Actions sociales','Oeuvres sociales','DRH/AS/OS'),
('10810','Direction des Ressources Humaines','Gestion des administrative RH','Gestion administrative du personnel des autres statuts','DRH/GARH/GAPAS'),
('10820','Direction des Ressources Humaines','Gestion des administrative RH','Gestion administrative du personnel de la fonction publique','DRH/GARH/GAPFP'),
('10830','Direction des Ressources Humaines','Gestion des administrative RH','Gestion des dépendenses du personnel','DRH/GARH/GDP'),
('10840','Direction des Ressources Humaines','Développement des RH','Aptitudes professionnelles et carrières','DRH/DRH/APC'),
('10850','Direction des Ressources Humaines','Développement des RH','Gestion prévisionnelle des RH','DRH/DRH/GPRH'),
('10860','Direction des Ressources Humaines','Développement des RH','Formation continue','DRH/DRH/FC'),
--La Direction de la Stratégie et des Statistiques
('10870','Direction de la Stratégie et des Statistiques','','','DSS'),
('10880','Direction de la Stratégie et des Statistiques','Développement des marchés','Marché du continent américain','DTSS/DM/MCA'),
('10890','Direction de la Stratégie et des Statistiques','Développement des marchés','Marché domestique','DSTS/DM/MD'),
('10900','Direction de la Stratégie et des Statistiques','Développement des marchés','Autres marchés','DSTS/DM/AM'),
('10910','Direction de la Stratégie et des Statistiques','Développement des marchés','Marché Européen','DSTS/DM/ME'),
('10920','Direction de la Stratégie et des Statistiques','Coopération','Coopération multilatérale','DSS/C/CM'),
('10930','Direction de la Stratégie et des Statistiques','Développement des marchés','Coopération bilatérale','DSTS/C/CB'),
('10940','Direction de la Stratégie et des Statistiques','Statiqtiques','Statiqtiques de la filière végétale','DSTS/S/SFV'),
('10950','Direction de la Stratégie et des Statistiques','Statiqtiques','Statiqtiques de la filière animale','DSTS/S/SFA'),
('10960','Direction de la Stratégie et des Statistiques','Statiqtiques','Enquêtes et recensement','DSS/S/ER'),
('10970','Direction de la Stratégie et des Statistiques','Statiqtiques','Stratégie des facteurs transversaux','DSTS/S/SFT'),
('10980','Direction de la Stratégie et des Statistiques','Stratégie','Stratégie de la filière végétale','DSTS/ST/STFV'),
('10990','Direction de la Stratégie et des Statistiques','Stratégie','Stratégie de la filière animale','DSTS/ST/STFA'),
('11000','Direction de la Stratégie et des Statistiques','Stratégie','Stratégie des aides et des incitations','DSTS/ST/STAI'),
('11010','Direction de la Stratégie et des Statistiques','Stratégie','Stratégie des facteurs transversaux','DSTS/ST/STFT')
go
create table Fonction(
	CodeFo int primary key identity(1,1),
	DescFo nvarchar(100)
)
go
insert into Fonction values
('Agent de Bureau'),
('Néant'),
('Chef de Service'),
('Chargé de Mission (Cabinet)'),
('Ingénieur'),
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
('Unité Centrale')
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
('Téléphone')
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
('Non résolu'),
('A transférer'),

('Différé'),

('Résolu')

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
