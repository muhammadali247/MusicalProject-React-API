import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Box, Button, Typography, Paper } from "@mui/material";
import axiosInstance from "@/utils/axiosInstance";

function ArtistDetailsForm() {
  const { artistId } = useParams(); 
  const navigate = useNavigate();

  const [artistData, setArtistData] = useState(null);

  useEffect(() => {
    // Fetch artist details
    axiosInstance
      .get(`https://localhost:7073/api/Artists/${artistId}`)
      .then((response) => {
        setArtistData(response.data);
      })
      .catch((error) => {
        console.error("Error fetching artist details:", error);
      });
  }, [artistId]);

  if (!artistData) {
    return <div>Loading...</div>;
  }

  return (
    <Box m="20px">
      <Paper elevation={3} padding="20px">
        <Typography variant="h4">{artistData.artistName}</Typography>
        <Typography variant="h6" color="textSecondary">
          Projects:
        </Typography>
        <ul>
          {artistData.projectNames.map((projectName) => (
            <li key={projectName}>
              {projectName}
            </li>
          ))}
        </ul>
        <Button
          variant="outlined"
          color="primary"
          onClick={() => {
            // Navigate to an edit page or open a modal/dialog for editing
            navigate(`/edit-artist/${artistId}`);
          }}
        >
          Edit
        </Button>
      </Paper>
    </Box>
  );
}

export default ArtistDetailsForm;
