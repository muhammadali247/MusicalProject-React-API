import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import Slider from "react-slick";
import {
  Card,
  CardActions,
  CardContent,
  CardMedia,
  Button,
  Typography,
} from "@mui/material";
import styles from "./HomeCarousel.module.scss";
import axiosInstance from "@/utils/axiosInstance";
import { useState, useEffect } from "react";
import { EVENTS_GETALL_URL, BASE_WEB_URL } from "@/constants/Urls";

const settings = {
  dots: true,
  infinite: true,
  speed: 2000,
  slidesToShow: 1,
  slidesToScroll: 1,
  autoplay: true,
};

function HomeCarousel() {
  const [events, setEvents] = useState([]); // state for storing events

  useEffect(() => {
    axiosInstance
      .get(EVENTS_GETALL_URL)
      .then((response) => {
        setEvents(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.error("Error fetching data: ", error);
      });
  }, []);

  return (
    <Slider {...settings}>
      {events.map((event) => (
        <Card key={event.id}>
          <CardMedia
            component="img"
            alt={event.title}
            height="500"
            image={`${BASE_WEB_URL}/${event.coverImageUrl}`}
          />
          <CardContent>
            <Typography variant="h5" component="div">
              {event.title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {event.description}
            </Typography>
          </CardContent>
          <CardActions>
            <Button size="small">Learn More</Button>
          </CardActions>
        </Card>
      ))}
      {/* Repeat for other slides */}
    </Slider>
  );
}

export default HomeCarousel;
