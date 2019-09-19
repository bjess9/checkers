-- ------------------------------------------------------------- PROCEDURE & FUNCTION CREATION ------------------------------------------------------------------------------------------------------------------------

-- RETURN DATA
-- 0 = UNSUCCESSFUL
-- 1 = SUCCESSFUL
-- 2+ = SECONDARY CONDITION

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
    
DROP PROCEDURE IF EXISTS 			grabOnlinePlayers//

CREATE PROCEDURE 					grabOnlinePlayers(
								IN 	prPlayerName 				CHAR(15))
	BEGIN
            
				SELECT 				playerName, 						playerStatus, 		rating 
                FROM 				playerdetail
                WHERE 				playerName 
                LIKE 				playerName 					<> 		prPlayerName 	
                AND 				playerStatus 				<> 		'Offline' 
                AND 				playerName 					!=      prPlayerName
                AND 				admin						<>		"Y"
                ORDER BY 			playerStatus 						DESC;
					
    END//
DELIMITER ;


-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			checkAdminStatus//

CREATE FUNCTION 					checkAdminStatus(
								 	prPlayerName 				CHAR(15))
									RETURNS						bit
                                    
	BEGIN
					
                    
	IF EXISTS
			(
                    
					SELECT * FROM	playerdetail
                    WHERE			playerName 				= 		prPlayerName
                    AND 			admin 					=		"Y"
                    
			)
                    
                    THEN
                    
					RETURN											1;
                    
			ELSE
                    
					RETURN											0;
                    
			END IF;
					
		
    END//    
	    
DELIMITER ;

DELIMITER //
    
DROP PROCEDURE IF EXISTS 			grabPlayer//

CREATE PROCEDURE 					grabPlayer(
								 	prPlayerName 				CHAR(15))
                                   
	BEGIN
			          
			SELECT 				playerName, 		playerStatus, 		rating, 	admin
			FROM 				playerdetail
            WHERE 				playerName = prPlayerName;
            
	END//
	    
DELIMITER ;

 


-- SELECT deleteGame (1);
/*
    Add player to game    
	show online players 	(procedure, selecting multiple columns, taking this data and displaying it, list of players)
        
	delete player 			(function, use player key to delete one row in playerDetails table)
        
	update player details	(procedure, one button re-writes all player columns with updates details from admin entry location)
    
	get my opponent
	delete a game
	add player
	make a move
	calculate if move is legal
	start a game

*/