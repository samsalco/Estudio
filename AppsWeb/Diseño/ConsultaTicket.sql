create table tsticket (
	TICID 	INT	 		PRIMARY KEY,-- Identificador
	TICCOD 	VARCHAR(7) 	NOT NULL,	-- Código
	TICCON	INT,					-- Control
	TICREQ	INT,					-- Requerimiento
	TICDES 	VARCHAR(100) NOT NULL,	-- Descripción
	TICSOL	VARCHAR(500) NOT NULL,	-- Solución
	TICIMP 	VARCHAR(500) NOT NULL,	-- Impacto
	TICOBS	VARCHAR(500) 			-- Observaciones 
)

select * from tsticket;
