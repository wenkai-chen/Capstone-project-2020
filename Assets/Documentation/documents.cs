// board size 433*238  mm  from "Validating and Calibrating the Nintendo Wii Balance Board to
// Derive Reliable Center of Pressure Measures" This distance is sensor distance
// Board number from 0,1,2 to 15 to Match API Document
//Board information 
//class Board1
    //Board1_length=433 mm, Board1_width=238mm all units in mm

    //Board1_x=0，Board1_y=0

    //This is Center position of Board the board 1 has global coordinate.
    //The unit will be mm  e.g. Board2_x= 250 

    //Vector 4 Board1_sensor.x y z w   e.g. Board1_sensor.x=3.25 
    // x is top right , y is top left  z is bottom right, w is bottom left.
    //These are original force of sensors, the unit are in kg 

    //Board1_COP_x_ratio is a number between -1 to +1 for its own coordinate

    //Board1_COP_x is a position units in mm it is in global coordinate 

    //Board1_Totalforce units in kg 
    //Boardn_Totalforce=Boardn_sensor.x+Boardn_sensor.y+Boardn_sensor.z+Boardn_sensor.w

    
//Parameters between Boards

//Vector2 Board1pointtoBoard2 a vector from Board1 coordinate to describe other boards location. 

