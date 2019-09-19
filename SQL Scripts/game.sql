DELIMITER //
    
DROP PROCEDURE IF EXISTS 			newGame//

CREATE PROCEDURE 					newGame(
								 	prChallenger			CHAR(15), 
									prOpponent 				CHAR(15))
					
	BEGIN
					DECLARE 		exit handler for sqlexception
                    
				BEGIN
                
                    ROLLBACK;
                    SELECT -1;
                    
				END;
                
                START TRANSACTION;
                IF (SELECT count(0) FROM game
					WHERE 	playerName1 = prChallenger OR
							playerName1 = prOpponent OR
							playerName2 = prChallenger OR
							playerName2 = prOpponent) > 0
				THEN
                
					COMMIT;
                    SELECT -1;
                    
				ELSE
					INSERT INTO 	game	(timeElapsed,timeStarted, currentTurn,	playerName1, playerName2)
                    VALUES 					('00:00:00', now(), 'r', prChallenger, prOpponent);
                    
					IF EXISTS
                    (
						SELECT * FROM game WHERE playerName1 = prChallenger AND playerName2 = prOpponent
					)
                    
                    THEN
                    
						COMMIT;
                        CALL 			changePlayerStatus(			4, 					prChallenger);
						CALL 			changePlayerStatus(			4, 					prOpponent);
						SELECT last_insert_id();
                        
					ELSE
                    
						COMMIT;
						SELECT -1;
                        
					END IF;
              END IF; 
    END//
DELIMITER ;
 CALL newGame ('bob123', 'sam');
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    
DELIMITER //
    
DROP FUNCTION IF EXISTS 			newGameV1//

CREATE FUNCTION 					newGameV1(
								 	prChallenger				CHAR(15), 
									prOpponent 					CHAR(15))
                                    RETURNS  					INT				
					
					
	BEGIN
					DECLARE 		lcGameID int;
     
                IF EXISTS 
                (
                    
					SELECT * FROM	game
                    WHERE			playerName1 = prChallenger
                    OR
									playerName2 = prOpponent
                    
				)
					THEN
                    
									RETURN   0;
                    
				ELSE
            
					INSERT INTO 	game						(timeElapsed, 		timeStarted, 		currentTurn,		playerName1, 		playerName2)
                    VALUES 										('00:00:00', 		now(), 				'r', 					prChallenger,		prOpponent);
                    
                   
					SET 			lcGameID							= 
                    (
									SELECT 			gameID 
									FROM 			game 
                                    WHERE 			playerName1 		= 		prChallenger
                                    AND				playerName2			=		prOpponent
					);
                    
                    IF 				lcGameID 							!= 		null
									THEN
									RETURN 										lcGameID;
									CALL 			changePlayerStatus(			4, 					prChallenger);
									CALL 			changePlayerStatus(			4, 					prOpponent);
								-- 	CALL newGameBoard (lcGameID);
					END IF;
                    
                    RETURN lcGameID;
                    
				END IF;
			
    END//
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    
DELIMITER //
    
DROP FUNCTION IF EXISTS 			newGameBoard//

CREATE FUNCTION 					newGameBoard(
								 	prGameID 					INT2)
									RETURNS  		BIT
	BEGIN
		
					INSERT INTO 	piecelocation	(x, 	y, 		colour,		gameID)
                    
					VALUES 							(1, 	0, 		'w', 			prGameID),
													(3, 	0, 		'w', 			prGameID),
													(5, 	0, 		'w', 			prGameID),
													(7, 	0, 		'w', 			prGameID),
													(0, 	1, 		'w', 			prGameID),
													(2, 	1, 		'w', 			prGameID),
													(4, 	1, 		'w', 			prGameID),
													(6, 	1, 		'w', 			prGameID),
													(1, 	2, 		'w', 			prGameID),
													(3, 	2, 		'w', 			prGameID),
													(5, 	2, 		'w', 			prGameID),
													(7, 	2, 		'w', 			prGameID),
													(0, 	5, 		'r', 			prGameID),
													(2, 	5, 		'r', 			prGameID),
													(4, 	5, 		'r', 			prGameID),
													(6, 	5, 		'r', 			prGameID),
													(1, 	6, 		'r', 			prGameID),
													(3, 	6, 		'r', 			prGameID),
													(5, 	6, 		'r', 			prGameID),
													(7, 	6, 		'r', 			prGameID),
													(0, 	7, 		'r', 			prGameID),
													(2, 	7, 		'r', 			prGameID),
													(4, 	7, 		'r', 			prGameID),
													(6, 	7, 		'r', 			prGameID);
        
        RETURN 1;
        
	END//    
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //

DROP PROCEDURE IF EXISTS 			leaveGame//

CREATE PROCEDURE 					leaveGame(
								IN 	prPlayerName 				CHAR(15),
                                IN	prGameID 					INT2, 
								OUT prLeaveGameResult	 		BIT)
	BEGIN
    
					CALL 			changePlayerStatus(			1, 		prPlayerName, 		@prStatusChangeResult);
			
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
                    
					SET				prLeaveGameResult 			= 		0;
                    
			ELSE
                    
					SET				prLeaveGameResult 			= 		1;
                    
			END IF;
			      
	END//
DELIMITER ;

    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			changePlayerStatus//

CREATE FUNCTION 					changePlayerStatus(
								 	prNewStatus					INT1,
                                 	prPlayerName 				CHAR(15))
									RETURNS						bit
                                    
	BEGIN
			          
			CASE
                     
			WHEN					prNewStatus  				= 		1
			
					THEN			
					UPDATE 			playerdetail 
					SET 			playerStatus 				= 		'Online'
					WHERE			playerName					=		prPlayerName;
					RETURN												1;
                    
			WHEN					prNewStatus  				= 		2                     
					THEN 			
					UPDATE 			playerdetail 
					SET 			playerStatus 				= 		'Offline'
					WHERE			playerName					=		prPlayerName;
					RETURN												1;
   
			WHEN 					prNewStatus				 	= 		3 
					THEN 			
					UPDATE 			playerdetail 
					SET 			playerStatus 				= 		'Waiting'
					WHERE			playerName					=		prPlayerName;
					RETURN												1;
                    
			WHEN 					prNewStatus  				= 		4 
					THEN 			
					UPDATE 			playerdetail 
					SET 			playerStatus 				= 		'Ingame'
					WHERE			playerName					=		prPlayerName;
					RETURN												1;
                    
			WHEN 					prNewStatus  				= 		5 
					THEN 			
					UPDATE 			playerdetail 
					SET 			playerStatus 				= 		'Challenged'
					WHERE			playerName					=		prPlayerName;
					RETURN												1;
   
			ELSE 						
					RETURN												0;
			END CASE;
        
    END//    
	    
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			checkForChallenge//

CREATE FUNCTION 					checkForChallenge(
								 	prPlayerName				CHAR(15))
									RETURNS						CHAR(15)
	BEGIN                                   
			
            DECLARE 		lcChallenger  CHAR(15);
            IF EXISTS
                                            
			(
					SELECT 		playerName
                                FROM 		playerdetail 
                                WHERE 		playerName 		= 		prPlayerName
                                AND			playerStatus	=		"Challenged"
			)
                    
                    THEN
                    
									
                   SET 		lcChallenger = (
								SELECT 		playerName
                                FROM 		playerdetail
                                WHERE 		playerName 	= 		prPlayerName
					);
                    
                    RETURN lcChallenger;
                    
			ELSE
                    
					RETURN											null;
                    
			END IF;  
	
    END//    


DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			checkForChallengeResponse//

CREATE FUNCTION 					checkForChallengeResponse(
								 	prPlayerName				CHAR(15))
									RETURNS						CHAR(10)
	BEGIN                                   
			DECLARE lcGameID CHAR(10);
            
            IF EXISTS
                                            
			(
                    
					SELECT gameID FROM 			game 
					WHERE 					playerName2		 = 		prPlayerName
                                      
			)
                    
                    THEN
                    
                    SET lcGameID = (SELECT gameID FROM 			game 
					WHERE 					playerName2		 = 		prPlayerName);
                    
					RETURN											lcGameID;
                    
			ELSE IF (SELECT playerStatus FROM playerdetail WHERE playerName = prPlayerName) != "Challenged"
                    THEN
					RETURN											"Declined";
                     
			ELSE
					RETURN 											"Waiting";
			END IF; 
            
            END IF;  
	
    END//    
	    
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			checkForGame//

CREATE FUNCTION 					checkForGame(
								 	prPlayerName				CHAR(15))
									RETURNS						int
	BEGIN                                   
			DECLARE lcGameID int;
            
            IF EXISTS
                                            
			(
                    
					SELECT gameID FROM 			game 
					WHERE 					playerName2		 = 		prPlayerName
                                      
			)
                    
                    THEN
                    
                    SET lcGameID = (SELECT gameID FROM 			game 
					WHERE 					playerName2		 = 		prPlayerName);
                    
					RETURN											lcGameID;
                    
			ELSE
					RETURN 											0;
			END IF; 
             
    END//    
	    
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP PROCEDURE IF EXISTS 			challengedGame//

CREATE PROCEDURE 					challengedGame(
									IN prPlayerName 				CHAR(15),
                                    OUT prOpponent CHAR(15),
                                    OUT prGameID INT)
                                    
	BEGIN
			         -- DECLARE lcOpponent 	char(15);
                    --  DECLARE lcGameID 			int;
			 IF EXISTS
                                            
			(
                    
					SELECT gameID FROM 			game 
					WHERE 					playerName2		 = 		prPlayerName
                                      
			)
                    
                    THEN
                    
                   SET prGameID = (SELECT gameID FROM game WHERE playerName2 = prPlayerName);
                    
				SELECT prGameID;
                     
			ELSE
					SET prGameID = 0;
                    SELECT prGameID;
			END IF; 
            
             IF EXISTS
                                            
			(
                    
					SELECT playerName1 FROM 			game 
					WHERE 					playerName2		 = 		prPlayerName
                                      
			)
                    
                    THEN
                    
                   SET prOpponent = (SELECT gameID FROM game WHERE playerName2 = prPlayerName);
                    
					SELECT										prOpponent;
                    
			ELSE
					SET prOpponent = 0;
                    SELECT prOpponent;
			END IF; 
            
	END//

DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			retrieveOpponent//

CREATE FUNCTION 					retrieveOpponent(
								 	prPlayerName				CHAR(15))
									RETURNS						CHAR(15)
	BEGIN                                   
			DECLARE lcOpponent CHAR(15);
            
            IF EXISTS
                                            
			(
                    
					SELECT playerName1 FROM 			game 
					WHERE 					playerName2		 = 		prPlayerName
                                      
			)
                    
                    THEN
                    
                    SET lcOpponent = (SELECT playerName1 FROM 			game 
					WHERE 					playerName2		 = 		prPlayerName);
                    
					RETURN											lcOpponent;
                     
			ELSE
					RETURN 											0;
			END IF; 
             
    END//    
	    
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			checkForResign//

CREATE FUNCTION 					checkForResign(
								 	prGameID					CHAR(15))
									RETURNS						int
	BEGIN                                   
			
            IF EXISTS
                                            
			(
								SELECT * FROM game WHERE gameID = prGameID
			)
                    
                    THEN
                    
                    RETURN 											1;
                    
			ELSE
                    
					RETURN											0;
                    
			END IF;  
	
    END//    

DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

DELIMITER //
    
DROP FUNCTION IF EXISTS 			endGame//

CREATE FUNCTION 					endGame(
								 	prGameID					CHAR(15))
									RETURNS						int
	BEGIN                                   
			
					DELETE
                    FROM			game
					WHERE			gameID 			= 		prGameID;
                    	
			IF EXISTS
			(
                    
					SELECT * FROM	game
                    WHERE			gameID 			= 		prGameID
                    
			)
                    
                    THEN
                    
					RETURN				 		0;
                    
			ELSE
                    
					RETURN 						1;
                    
			END IF;
	
    END//    

DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    
DELIMITER //
    
DROP FUNCTION IF EXISTS 			checkTurn//

CREATE FUNCTION 					checkTurn(
								 	prGameID				INT2) 
									RETURNS  					 CHAR(2)
					
	BEGIN
					DECLARE lcCurrentTurn char(1);
                    
                    IF EXISTS
                    (
						SELECT currentTurn FROM game WHERE gameID = prGameID
                    )
                    
                    THEN
                    
						SET lcCurrentTurn = (SELECT currentTurn FROM game WHERE gameID = prGameID);
                    
						RETURN lcCurrentTurn;
                    
                    ELSE
                    
						RETURN 0;
                    
                    END IF;
                    			
    END//
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    
DELIMITER //
    
DROP FUNCTION IF EXISTS 			changeTurn//

CREATE FUNCTION 					changeTurn(
								 	prGameID				INT2) 
									RETURNS  				INT1
					
					
	BEGIN
					IF (SELECT currentTurn FROM game WHERE gameID = prGameID) = 'r'
                    
                    THEN
                    
						UPDATE 			game 
						SET 			currentTurn 			= 		'w'
						WHERE			gameID					=		prGameID;
						RETURN 1;
                        
                    ELSE IF (SELECT currentTurn FROM game WHERE gameID = prGameID) = 'w'
                    
                    THEN
                    
						UPDATE 			game 
						SET 			currentTurn 			= 		'r'
						WHERE			gameID					=		prGameID;
						RETURN 1;
                        
					ELSE 
                    
						RETURN 0;
                        
					END IF;
                    
                    END IF;
                    
    END//
DELIMITER ;


-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    
DELIMITER //
    
DROP FUNCTION IF EXISTS 			countCheckers//

CREATE FUNCTION 					countCheckers(
								 	prGameID				INT2) 
									RETURNS  				INT1
					
	BEGIN
			DECLARE lcCheckersCount INT1;
            
            
			SET lcCheckersCount =	(SELECT count(0) FROM piecelocation
									WHERE 	gameID = prGameID);
                    
			RETURN lcCheckersCount;
                    
    END//
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    
DELIMITER //
    
DROP FUNCTION IF EXISTS 			countOpponentsCheckers//

CREATE FUNCTION 					countOpponentsCheckers(
								 	prGameID				INT2,
                                    prColor					CHAR(2)) 
									RETURNS  				INT1
					
	BEGIN
			DECLARE lcCheckersCount INT1;
            
            
			SET lcCheckersCount =	(SELECT count(0) FROM piecelocation
									WHERE 	gameID = prGameID
                                    AND		colour  != prColor);
                    
			RETURN lcCheckersCount;
                    
    END//
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    
DELIMITER //
    
DROP FUNCTION IF EXISTS 			scoreUpdate//

CREATE FUNCTION 					scoreUpdate(
								 	prPlayerWinner				CHAR(15),
                                    prPlayerLoser				CHAR(15)) 
									RETURNS  				INT1
					
					
	BEGIN
							UPDATE 			playerdetail					
							SET				rating			=		rating + 10											
							WHERE 			playerName		=		prPlayerWinner;
                            
                            IF (SELECT rating FROM playerdetail WHERE playerName = prPlayerLoser) > 9
                            THEN
                            
                            UPDATE			playerdetail
                            SET 			rating			=		rating - 10
                            WHERE			playerName		=		prPlayerLoser;
                            RETURN 1;
                            
                            ELSE
                            
                            UPDATE			playerdetail
                            SET 			rating			=		0
                            WHERE			playerName		=		prPlayerLoser;
                            RETURN 1;
                            
                            END IF;
    END//
DELIMITER ;