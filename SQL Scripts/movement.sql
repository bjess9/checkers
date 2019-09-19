-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

DELIMITER //
    
DROP PROCEDURE IF EXISTS 			grabCounters//

CREATE PROCEDURE 					grabCounters(
								IN 	prGameID 				int)
	BEGIN
            
				SELECT 				*
                FROM 				piecelocation
                WHERE 				gameID 		= 		prGameID;
					
    END//
DELIMITER 


-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

RETURNS
-- 0 = INVALID MOVE
-- 1 = VALID MOVE TO TILE
-- 2 = VALID JUMP MOVE
-- 3 = INVALID MOVE JUMP OFF GRID
-- 4 = 

DELIMITER //
    
DROP FUNCTION IF EXISTS 			moveChecker//

CREATE FUNCTION 					moveChecker(
								 	prGameID 					INT2,
                                    prColor					 	CHAR(2),
                                    prSelectedCheckerRow 		INT1,
                                    prSelectedCheckerCol		INT1,
                                    prSelectedMoveToRow			INT1,
                                    prSelectedMoveToCol			INT1)                                 
                                    
									RETURNS  		INT1
	BEGIN
    
			DECLARE lcCheckerType char(2);
            
            SET lcCheckerType = (	SELECT colour 
									FROM piecelocation 
                                    WHERE gameID = prGameID
                                    AND y = prSelectedCheckerRow
                                    AND x = prSelectedCheckerCol);
									
			-- CANT MAKE KING MOVE DECISION BASED OFF prCOLOR, EITHER MAKE BEING A KING A FLAG OR USE A SELECT STATEMENT]
            -- TO SOMEHOW DETERMINE THAT A PIECE IS A KING WHEN PASSED IN
            
            -- IF LABEL HAS KING IMAGE PASS IN wC, rC ????????
			IF 		(prSelectedMoveToRow	=  (prSelectedCheckerRow - 1) 
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol - 1)
                AND prColor = 'r') 
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow - 1) 
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol + 1)
                AND prColor = 'r')
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow + 1)
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol - 1)
                AND prColor = 'w')
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow + 1) 
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol + 1)
                AND prColor = 'w')
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow - 1) 
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol - 1)
                AND lcCheckerType = 'rC') 
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow - 1) 
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol + 1)
                AND lcCheckerType = 'rC')
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow + 1)
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol - 1)
                AND lcCheckerType = 'rC')
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow + 1) 
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol + 1)
                AND lcCheckerType = 'rC')
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow - 1) 
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol - 1)
                AND lcCheckerType = 'wC') 
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow - 1) 
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol + 1)
                AND lcCheckerType = 'wC')
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow + 1)
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol - 1)
                AND lcCheckerType = 'wC')
                OR
					(prSelectedMoveToRow	=  (prSelectedCheckerRow + 1) 
                AND prSelectedMoveToCol 	=  (prSelectedCheckerCol + 1)
                AND lcCheckerType = 'wC')
                
			
                   
                THEN
                
                IF  (prColor OR lcCheckerType) = (	SELECT colour 
									FROM piecelocation 
									WHERE prSelectedCheckerRow = y 
									AND prSelectedCheckerCol = x
                                    AND gameID = prGameID)
                                
					THEN
                    
                    IF EXISTS 
                    (
								SELECT * FROM piecelocation 
                                WHERE y = prSelectedMoveToRow
                                AND x = prSelectedMoveToCol
                                AND gameID = prGameID
					)
                    
                    THEN
                    
						IF prColor != (SELECT colour FROM piecelocation 
                                WHERE y = prSelectedMoveToRow
                                AND x = prSelectedMoveToCol
                                AND gameID = prGameID)
                                
						THEN
							IF 	(prSelectedMoveToRow + 1) > 7
								OR (prSelectedMoveToRow - 1) < 0
								OR (prSelectedMoveToCol + 1) > 7
								OR (prSelectedMoveToCol - 1) < 0
                            
                            THEN
                            
								RETURN 3;
                            
                            ELSE
                            
								RETURN 2;
                                
							END IF;
                        ELSE 
                        
							RETURN 0;
                        
                        END IF;
                    
                    ELSE
                                
						UPDATE 			piecelocation						
						SET				y			=		prSelectedMoveToRow,
										x			=		prSelectedMoveToCol
										
						WHERE 			y			=		prSelectedCheckerRow 
						AND				x			=		prSelectedCheckerCol
						AND				gameID		=		prGameID;
			
						
						IF (prColor = 'r' 
							AND prSelectedMoveToRow = 0)
						THEN
							UPDATE 			piecelocation						
							SET				colour			=		'rC'
											
							WHERE 			y			=		prSelectedMoveToRow 
							AND				x			=		prSelectedMoveToCol
							AND				gameID		=		prGameID;
                            RETURN 1;
						ELSE IF (prColor = 'w' 
							AND prSelectedMoveToRow = 7)
						THEN
							UPDATE 			piecelocation						
							SET				colour			=		'wC'
											
							WHERE 			y			=		prSelectedMoveToRow 
							AND				x			=		prSelectedMoveToCol
							AND				gameID		=		prGameID;
							RETURN 1;
                        END IF;
                        RETURN 1;
						END IF;
                    END IF;
                
                ELSE
                
					RETURN 0;
                
                END IF;
            
			ELSE
					-- RETURN INVALID MOVE
				RETURN 0;
                
			END IF;
	END//    
    
    
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    

-- 2 = DOUBLE JUMP POSSIBLE	
DELIMITER //
    
DROP FUNCTION IF EXISTS 			jumpMove//

CREATE FUNCTION 					jumpMove(
								 	prGameID 					INT2,
                                    prColor					 	CHAR(2),
                                    prSelectedCheckerRow 		INT1,
                                    prSelectedCheckerCol		INT1,
                                    prSelectedMoveToRow			INT1,
                                    prSelectedMoveToCol			INT1)                                 
                                    
									RETURNS  		INT1
	BEGIN
			DECLARE lcNewRow INT1;
            DECLARE lcNewCol INT1;
            
			DECLARE lcCheckerType char(2);
            
            DECLARE lcDoubleJumpCheck int1;
            
            SET lcCheckerType = (	SELECT colour 
									FROM piecelocation 
                                    WHERE gameID = prGameID
                                    AND y = prSelectedCheckerRow
                                    AND x = prSelectedCheckerCol);
                                    
			CASE
                     
			WHEN
            prSelectedMoveToRow		= prSelectedCheckerRow + 1 AND
			prSelectedMoveToCol 	= prSelectedCheckerCol + 1
			
					THEN		
                    DELETE FROM piecelocation 
                    WHERE y = prSelectedCheckerRow
                    AND x = prSelectedCheckerCol
                    AND gameID = prGameID;
                    
                    INSERT INTO 	piecelocation				(x, 		y, 		colour,		gameID)
                    VALUES 										(prSelectedMovetoCol + 1, prSelectedMoveToRow + 1, lcCheckerType, prGameID);
                    
                    
                    SET lcNewRow = prSelectedMoveToRow + 1;
                    SET lcNewCol = prSelectedMoveToCol + 1;
                    
						DELETE FROM piecelocation 
						WHERE y = prSelectedMoveToRow 
						AND x = prSelectedMoveToCol
						AND gameID = prGameID;
                        
							IF 		(lcCheckerType = 'r' 
							AND 	lcNewRow = 0)
									THEN
										UPDATE 			piecelocation						
										SET				colour			=		'rC'
														
										WHERE 			y			=		prSelectedMovetoCol + 1 
										AND				x			=		prSelectedMoveToRow + 1
										AND				gameID		=		prGameID;
                                        
                                        SET lcDoubleJumpCheck = (SELECT doubleJumpCheck(	prGameID, 
																	prColour, 
                                                                    lcCheckerType, 
                                                                    prSelectedMoveToRow + 1, 
                                                                    prSelectedMoveToCol + 1));
                                                                    
											IF lcDoubleJumpCheck = 1                                            
                                            THEN
                                            
												RETURN 2;
                                            
                                            ELSE
                                            
                                            RETURN 1;
                                            
                                            END IF;
                                        
						ELSE IF 	(lcCheckerType = 'w' 
							AND 	lcNewRow = 0)
									THEN
										UPDATE 			piecelocation						
										SET				colour			=		'wC'
														
										WHERE 			y			=		prSelectedMovetoCol + 1 
										AND				x			=		prSelectedMoveToRow + 1
										AND				gameID		=		prGameID;
                                        
                                        SET lcDoubleJumpCheck = (SELECT doubleJumpCheck(	prGameID, 
																	prColour, 
                                                                    lcCheckerType, 
                                                                    prSelectedMoveToRow + 1, 
                                                                    prSelectedMoveToCol + 1));
                                                                    
											IF lcDoubleJumpCheck = 1                                            
                                            THEN
                                            
												RETURN 2;
                                            
                                            ELSE
                                            
                                            RETURN 1;
                                            
                                            END IF;
                                        
                        END IF;
                        END IF;
                        
					RETURN												1;
                    
			WHEN
            prSelectedMoveToRow 	= prSelectedCheckerRow - 1 AND
			prSelectedMoveToCol 	= prSelectedCheckerCol - 1     
                                    
					THEN			
                    
                    DELETE FROM piecelocation 
                    WHERE y = prSelectedCheckerRow
                    AND x = prSelectedCheckerCol
                    AND gameID = prGameID;
                    
                    INSERT INTO 	piecelocation				(x, 		y, 		colour,		gameID)
                    VALUES 										(prSelectedMovetoCol - 1, prSelectedMoveToRow - 1, lcCheckerType, prGameID);
                   
					SET lcNewRow = prSelectedMoveToRow - 1;
                    SET lcNewCol = prSelectedMoveToCol - 1;
                   
						DELETE FROM piecelocation 
						WHERE y = prSelectedMoveToRow 
						AND x = prSelectedMoveToCol
						AND gameID = prGameID;
                        
							IF 		(lcCheckerType = 'r' 
							AND 	lcNewRow = 0)
									THEN
										UPDATE 			piecelocation						
										SET				colour			=		'rC'
														
										WHERE 			y			=		prSelectedMovetoCol - 1 
										AND				x			=		prSelectedMoveToRow - 1
										AND				gameID		=		prGameID;
                                        
                                        SET lcDoubleJumpCheck = (SELECT doubleJumpCheck(	prGameID, 
																	prColour, 
                                                                    lcCheckerType, 
                                                                    prSelectedMoveToRow - 1, 
                                                                    prSelectedMoveToCol - 1));
                                                                    
											IF lcDoubleJumpCheck = 1                                            
                                            THEN
                                            
												RETURN 2;
                                            
                                            ELSE
                                            
                                            RETURN 1;
                                            
                                            END IF;
                                        
						ELSE IF 	(lcCheckerType = 'w' 
							AND 	lcNewRow = 0)
									THEN
										UPDATE 			piecelocation						
										SET				colour			=		'wC'
														
										WHERE 			y			=		prSelectedMoveToRow - 1
										AND				x			=		prSelectedMoveToCol - 1
										AND				gameID		=		prGameID;
                                        
                                        SET lcDoubleJumpCheck = (SELECT doubleJumpCheck(	prGameID, 
																	prColour, 
                                                                    lcCheckerType, 
                                                                    prSelectedMoveToRow - 1, 
                                                                    prSelectedMoveToCol - 1));
                                                                    
											IF lcDoubleJumpCheck = 1                                            
                                            THEN
                                            
												RETURN 2;
                                            
                                            ELSE
                                            
                                            RETURN 1;
                                            
                                            END IF;
                                        
                        END IF;
                        END IF;
					RETURN												1;
	
			WHEN
            prSelectedMoveToRow 	= prSelectedCheckerRow + 1 AND
			prSelectedMoveToCol 	= prSelectedCheckerCol - 1
                                    
					THEN		
                    DELETE FROM piecelocation 
                    WHERE y = prSelectedCheckerRow
                    AND x = prSelectedCheckerCol
                    AND gameID = prGameID;
                    
                    INSERT INTO 	piecelocation				(x, 		y, 		colour,		gameID)
                    VALUES 										(prSelectedMovetoCol - 1, prSelectedMoveToRow + 1, lcCheckerType, prGameID);
                   
					SET lcNewRow = prSelectedMoveToRow + 1;
                    SET lcNewCol = prSelectedMoveToCol - 1;
                   
						DELETE FROM piecelocation 
						WHERE y = prSelectedMoveToRow 
						AND x = prSelectedMoveToCol
						AND gameID = prGameID;
                        
							IF 		(lcCheckerType = 'r' 
							AND 	lcNewRow = 0)
									THEN
										UPDATE 			piecelocation						
										SET				colour			=		'rC'
														
										WHERE 			y			=		prSelectedMovetoCol - 1 
										AND				x			=		prSelectedMoveToRow + 1
										AND				gameID		=		prGameID;
                                        
                                        SET lcDoubleJumpCheck = (SELECT doubleJumpCheck(	prGameID, 
																	prColour, 
                                                                    lcCheckerType, 
                                                                    prSelectedMoveToRow + 1, 
                                                                    prSelectedMoveToCol - 1));
                                                                    
											IF lcDoubleJumpCheck = 1                                            
                                            THEN
                                            
												RETURN 2;
                                            
                                            ELSE
                                            
                                            RETURN 1;
                                            
                                            END IF;
                                        
						ELSE IF 	(lcCheckerType = 'w' 
									AND lcNewRow = 0)
									THEN
										UPDATE 			piecelocation						
										SET				colour			=		'wC'
														
										WHERE 			y			=		prSelectedMoveToRow + 1
										AND				x			=		prSelectedMoveToCol - 1
										AND				gameID		=		prGameID;
                                        
                                        SET lcDoubleJumpCheck = (SELECT doubleJumpCheck(	prGameID, 
																	prColour, 
                                                                    lcCheckerType, 
                                                                    prSelectedMoveToRow + 1, 
                                                                    prSelectedMoveToCol - 1));
                                                                    
											IF lcDoubleJumpCheck = 1                                            
                                            THEN
                                            
												RETURN 2;
                                            
                                            ELSE
                                            
                                            RETURN 1;
                                            
                                            END IF;
                                        
                        END IF;
                        END IF;

					RETURN												1;
                    
			WHEN 
            prSelectedMoveToRow 	= prSelectedCheckerRow - 1 AND
			prSelectedMoveToCol 	= prSelectedCheckerCol + 1
                                    
					THEN		
                    DELETE FROM piecelocation 
                    WHERE y = prSelectedCheckerRow
                    AND x = prSelectedCheckerCol
                    AND gameID = prGameID;
                    
                    INSERT INTO 	piecelocation				(x, 		y, 		colour,		gameID)
                    VALUES 										(prSelectedMovetoCol + 1, prSelectedMoveToRow - 1, lcCheckerType, prGameID);
                   
					SET lcNewRow = prSelectedMoveToRow - 1;
                    SET lcNewCol = prSelectedMoveToCol + 1;
                   
						DELETE FROM piecelocation 
						WHERE y = prSelectedMoveToRow 
						AND x = prSelectedMoveToCol
						AND gameID = prGameID;
                        
							IF 		(lcCheckerType = 'r' 
									AND lcNewRow = 0)
								THEN
										UPDATE 			piecelocation						
										SET				colour			=		'rC'
														
										WHERE 			y			=		prSelectedMovetoCol + 1 
										AND				x			=		prSelectedMoveToRow - 1
										AND				gameID		=		prGameID;
                                        
                                        SET lcDoubleJumpCheck = (SELECT doubleJumpCheck(	prGameID, 
																	prColour, 
                                                                    lcCheckerType, 
                                                                    prSelectedMoveToRow - 1, 
                                                                    prSelectedMoveToCol + 1));
                                                                    
											IF lcDoubleJumpCheck = 1                                            
                                            THEN
                                            
												RETURN 2;
                                            
                                            ELSE
                                            
                                            RETURN 1;
                                            
                                            END IF;
                                            
							ELSE IF (lcCheckerType = 'w' 
									AND lcNewRow = 0)
									THEN
										UPDATE 			piecelocation						
										SET				colour			=		'wC'
														
										WHERE 			y			=		prSelectedMoveToRow - 1
										AND				x			=		prSelectedMoveToCol + 1
										AND				gameID		=		prGameID;
                                        
                                        SET lcDoubleJumpCheck = (SELECT doubleJumpCheck(	prGameID, 
																	prColour, 
                                                                    lcCheckerType, 
                                                                    prSelectedMoveToRow - 1, 
                                                                    prSelectedMoveToCol + 1));
                                                                    
											IF lcDoubleJumpCheck = 1                                            
                                            THEN
                                            
												RETURN 2;
                                            
                                            ELSE
                                            
                                            RETURN 1;
                                            
                                            END IF;
                                            
							END IF;
                        END IF;
                        
					RETURN												1;
                    
			ELSE 						
					RETURN												0;
			END CASE;
		
	END//    
    
    
DELIMITER ;

-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    


DELIMITER //
    
DROP FUNCTION IF EXISTS 			doubleJumpCheck//

CREATE FUNCTION 					doubleJumpCheck(
								 	prGameID 					INT2,
                                    prColor					 	CHAR(2),
                                    prCheckerType				CHAR(2),
                                    prCheckerRow 		INT1,
                                    prCheckerCol		INT1)                                 
                                    
									RETURNS  		INT1
	BEGIN

			CASE
            
				WHEN	prColor != (SELECT colour FROM piecelocation 
									WHERE y = prCheckerRow + 1 
                                    AND x = prCheckerCol + 1
                                    AND gameID = prGameID)
                                    
						THEN
                        
                        IF EXISTS 
                        (	
									SELECT * FROM piecelocation
									WHERE gameID = prGameID
                                    AND y = prCheckerRow + 2
                                    AND x = prCheckerCol + 2
						)
                        THEN
                        
							RETURN 0;
                        
                        ELSE
                        
							RETURN 1;
                        
                        END IF;
				
				WHEN	prColor != (SELECT colour FROM piecelocation 
									WHERE y = prCheckerRow - 1 
                                    AND x = prCheckerCol - 1)
                                    
						THEN
                        
                        IF EXISTS 
                        (	
									SELECT * FROM piecelocation
									WHERE gameID = prGameID
                                    AND y = prCheckerRow - 2
                                    AND x = prCheckerCol - 2
						)
                        THEN
                        
							RETURN 0;
                        
                        ELSE
                        
							RETURN 1;
                        
                        END IF;
                                    
				WHEN	prColor != (SELECT colour FROM piecelocation 
									WHERE y = prCheckerRow - 1 
                                    AND x = prCheckerCol + 1)
                                    
						THEN
                        
                        IF EXISTS 
                        (	
									SELECT * FROM piecelocation
									WHERE gameID = prGameID
                                    AND y = prCheckerRow - 2
                                    AND x = prCheckerCol + 2
						)
                        THEN
                        
							RETURN 0;
                        
                        ELSE
                        
							RETURN 1;
                        
                        END IF;
                                    
				WHEN	prColor != (SELECT colour FROM piecelocation 
									WHERE y = prCheckerRow + 1 
                                    AND x = prCheckerCol - 1)
                                    
						THEN
                        
                        IF EXISTS 
                        (	
									SELECT * FROM piecelocation
									WHERE gameID = prGameID
                                    AND y = prCheckerRow + 2
                                    AND x = prCheckerCol - 2
						)
                        THEN
                        
							RETURN 0;
                        
                        ELSE
                        
							RETURN 1;
                        
                        END IF;
				
			END CASE;
		
	END//    
    
    
DELIMITER ;