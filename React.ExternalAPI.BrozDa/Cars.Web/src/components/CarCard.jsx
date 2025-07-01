import "../css/CarCard.css";
import { useNavigate } from "react-router-dom";

function CarCard({carId, carName, imgUrl }) {
  const navigate = useNavigate();

  const handleClick = () => {
    navigate(`/cars/${carId}`);
  };

  return (
    <div className="car-card" onClick={handleClick}>
      <div className="car-name">
        <p>{carName}</p>
      </div>
      <div className="car-image">
        <img src={imgUrl} alt={`Image of ${carName} car`} />
      </div>
    </div>
  );
}

export default CarCard;