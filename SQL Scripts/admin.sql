
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
    
DROP PROCEDURE IF EXISTS 			grabPlayers//

CREATE PROCEDURE 					grabPlayers(
								IN 	prPlayerName 				CHAR(15))
	BEGIN
            
				SELECT 				playerName, 						playerStatus, 	playerPassword, 	rating, 	admin
                FROM 				playerdetail
                WHERE 				playerName 
				LIKE 				playerName 					<> 		prPlayerName
                AND 				playerName 					!=      prPlayerName
                ORDER BY 			playerStatus 						DESC;
					
    END//
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
    
DROP PROCEDURE IF EXISTS 			grabGames//

CREATE PROCEDURE 					grabGames(
								IN 	prPlayerName 				CHAR(15))
	BEGIN
            
				SELECT 				*
                FROM 				game
                ORDER BY 			gameID 						DESC;
					
    END//
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			addOrEditPlayer//

CREATE FUNCTION 					addOrEditPlayer(
								 	prPlayerName				CHAR(15),
                                    prPassword					CHAR(15),
                                    prStatus					CHAR(10),
                                    prRating					smallint,
                                    prAdmin						CHAR(1),
                                    prAddOrEdit					bit)                                   
									RETURNS						bit
                                    
	BEGIN
			          
			CASE
                     
			WHEN					prAddOrEdit  			= 		0
			
					THEN			
					INSERT INTO 	playerdetail 					(playerName, 		playerPassword, 	playerStatus,	rating,			admin)
					VALUES 											(prPlayerName, 		UNHEX(sha2(prPassword, 256)), 		'Offline', 		prRating,		prAdmin);
                    
					RETURN											1;
                    
			WHEN					prAddOrEdit   			= 		1                     
					THEN 			
					UPDATE 			playerdetail 						
					SET				playerStatus			=		prStatus,
									rating					=		prRating,
                                    admin					=		prAdmin
					WHERE 			playerName				=		prPlayerName;
                                    
					RETURN											1;
   
			ELSE
					RETURN											0;
			END CASE;
            
	END//
	    
DELIMITER ;
  
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			deletePlayer//

CREATE FUNCTION 					deletePlayer(
								 	prPlayerName				CHAR(15))
                                 	RETURNS						bit
                                    
	BEGIN
			          
					DELETE 
					FROM 			playerdetail
					WHERE 			playerName 				= 		prPlayerName;
            
            IF EXISTS
			(
                    
					SELECT * FROM	playerdetail
                    WHERE			playerName 				= 		prPlayerName
                                      
			)
                    
                    THEN
                    
					RETURN											0;
                    
			ELSE
                    
					RETURN											1;
                    
			END IF;
        
    END//    
	    
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			deleteGame//

CREATE FUNCTION 					deleteGame(
								 	prGameID						smallint)
                                 	RETURNS						bit
                                    
	BEGIN
			        DELETE 
                    FROM 			piecelocation
                    WHERE 			gameID 				= 		prGameID;
                    
					DELETE 
					FROM 			game
					WHERE 			gameID 				= 		prGameID;
                    
                     IF EXISTS
			(
                    
					SELECT * FROM	game
                    WHERE			gameID 				= 		prGameID
                                      
			)
                    
                    THEN
                    
					RETURN											0;
                    
			ELSE
                    
					RETURN											1;
                    
			END IF;

    END//    
	    
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			updateNewUserPassword//

CREATE FUNCTION 					updateNewUserPassword(
								 	prPlayerName 					CHAR(15),
                                    prNewPassword					CHAR(15))                                    
									RETURNS						bit
                                    
	BEGIN
			          
					UPDATE 			playerdetail 						
					SET				playerPassword 				= 		UNHEX(sha2(prNewPassword, 256))									
					WHERE 			playerName				=		prPlayerName;
                    
                         IF EXISTS
			(
                    
					SELECT * FROM	playerdetail
                    WHERE			playerName 				= 		prPlayerName
                    AND				playerPassword 				=		UNHEX(sha2(prNewPassword, 256))
                                      
			)
                    
                    THEN
                    
					RETURN											1;
                    
			ELSE
                    
					RETURN											0;
                    
			END IF;
			
	END//
	    
DELIMITER ;
