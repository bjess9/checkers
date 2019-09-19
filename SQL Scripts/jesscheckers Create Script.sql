-- ----------------------------------------------------------------------- CREATE SCRIPT ------------------------------------------------------------------------------------------------------------------------

USE jesscheckers;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

drop table if exists 	pieceLocation;
drop table if exists 	game;
drop table if exists 	playerDetail;  

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  CREATE TABLE playerDetail(
	playerName 			char(15) 		not null 		primary key,
	playerPassword 		binary(32) 		not null,  		-- temporarily char for sample data, will use appropriate datatype for password hash later on
    playerStatus 		char(10) 		not null,
    rating 				smallint 		not null,
    admin 				char(1) 		not null,
    version 			TIMESTAMP ON UPDATE CURRENT_TIMESTAMP NOT NULL
    
    )ENGINE=InnoDB;
    
    
    -- current turn 0 = red
 CREATE TABLE game(
	gameID 				smallint 		not null 		auto_increment		primary key ,
    timeElapsed 		time 			not null,
    timeStarted 		timestamp 		not null,
    currentTurn 		char(1),         
    playerName1 		char(15) 		not null,
    playerName2 		char(15),
    
    FOREIGN KEY 		fkPlayerName(playerName1)    	REFERENCES 			playerDetail(playerName)				,    
	FOREIGN KEY 		fkPlayerName2(playerName2)     	REFERENCES 			playerDetail(playerName)			
     
    )ENGINE=InnoDB;
    
    
    
CREATE TABLE pieceLocation(
	x 					smallint,
    y 					smallint,
    colour 				CHAR(2) 		not null,
    gameID 				smallint 		not null,
    
    FOREIGN KEY 		fk_gameID(gameID)    			REFERENCES 			game(gameID) ON DELETE CASCADE										
    
    )ENGINE=InnoDB;
    
    -- Foreign keys are automatically indexes within InnoDB, this covers most of my indexing criterea.
    ALTER TABLE piecelocation ADD INDEX x (x);
    ALTER TABLE piecelocation ADD INDEX y (y);
    ALTER TABLE piecelocation ADD INDEX colour (colour);
    
    
 
    



