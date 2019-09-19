DELIMITER //
DROP FUNCTION IF EXISTS 			login//

CREATE FUNCTION 					login(

								 	prPlayerName 				CHAR(15), 
                                 	prPlayerPassword 			CHAR(15)) 
									RETURNS 					INT1
                                
	BEGIN
					DECLARE 		lcChangePlayerStatusResult  BIT 	DEFAULT 1; 
			IF EXISTS 
			(
					SELECT * FROM 	playerdetail            
					WHERE 			playerName 					= 		prPlayerName            
					AND         	playerPassword	 			= 		UNHEX(sha2(prPlayerPassword, 256))
                    AND 			playerStatus 				=		"Offline"
                    
			)				
            
					THEN 
                  
					SET 			lcChangePlayerStatusResult 	= 		changePlayerStatus(	1, 	prPlayerName);
                
			IF 						lcChangePlayerStatusResult 	= 		1 
					THEN
					RETURN 												0; -- LOGIN SUCCESS -- If query finds player in dn 
			END IF;
                    
			ELSEIF EXISTS
			(
					SELECT * FROM 	playerdetail            
					WHERE 			playerName 					= 		prPlayerName
			)                
					THEN            
					RETURN												1; -- PASSWORD INCORRECT -- If query can find the name but not the password 
                
			ELSE 
            
					RETURN												2; -- NEW USER -- If query cant find the user at all
                    
			END IF;
        
	END//
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
	-- register 
    
DELIMITER //

DROP FUNCTION IF EXISTS 			register//

CREATE FUNCTION 					register(
								 	prPlayerName 				CHAR(15), 
								 	prPlayerPassword 			CHAR(15))
									RETURNS  					BIT

	BEGIN
		        
			INSERT INTO playerdetail	
            (
									playerName,			playerPassword,			playerStatus,	rating,		admin
			)
            VALUES 						
            (
									prPlayerName,		UNHEX(sha2(prPlayerPassword, 256)),		'Online',		'0',		'N'                                    
			);
            
            IF EXISTS            
            (
					SELECT * FROM 	playerdetail
					WHERE 			playerName 					= 		prPlayerName
					AND   			playerPassword 				= 		UNHEX(sha2(prPlayerPassword, 256))
			)
					THEN
                
					RETURN 												1;
			ELSE 
            
					RETURN								 				0;
                                    
            END IF;
                    
	END//
DELIMITER ;

    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER $$
DROP FUNCTION IF EXISTS logout$$
CREATE DEFINER=`root`@`localhost` FUNCTION `logout`(
								 	prPlayerName 				CHAR(15)) RETURNS bit(1)
BEGIN
					DECLARE 		lcChangePlayerStatusResult  bit 	DEFAULT 1;
					
                    SET 			lcChangePlayerStatusResult 	= 		changePlayerStatus(	2, 	prPlayerName);
                    
                    RETURN 1;
                    
	END$$
DELIMITER ;


DELIMITER //

DROP PROCEDURE IF EXISTS 			disconnect//

CREATE PROCEDURE 					disconnect(
								IN 	prPlayerName 				CHAR(15),
                                IN	prGameID 					INT2, 
								OUT prDisconnectResult	 		BIT)
	BEGIN
    
					CALL 			changePlayerStatus(			2, 		prPlayerName, 		@prStatusChangeResult);
			
                   
			 		DELETE 
                    
					FROM		 	piecelocation
					WHERE 			piecelocation.gameID        = 		prGameID;  
                    
                    DELETE
                    
		 			FROM			game
					WHERE			gameID 						= 		prGameID;
                    	
			IF EXISTS
			(
                    
					SELECT * FROM	game
                    WHERE			gameID = prGameID
                    
			)
                    
                    THEN
                    
					SET				prDisconnectResult 			= 		0;
                    
			ELSE
                    
					SET				prDisconnectResult 			= 		1;
                    
			END IF;
			      
	END//
DELIMITER ;