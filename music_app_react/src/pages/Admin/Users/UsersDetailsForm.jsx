import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
  Box,
  Typography,
  Paper,
  Card,
  CardContent,
  Avatar,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Button,
  useTheme, 
  Chip 
} from "@mui/material";
import axiosInstance from "@/utils/axiosInstance";
import { USERS_GET_BY_ID_LIMITED_URL, BASE_WEB_URL} from "@/constants/Urls";
import { tokens } from "@/layouts/Admin/AdminTheme";

const InfoPair = ({ label, value }) => {
  return (
    <Box display="flex" alignItems="center" marginBottom={1}>
      <Typography variant="h5" style={{ minWidth: '120px', fontWeight: 'bold' }}>{label}</Typography>
      <Typography variant="h5" style={{ fontWeight: 'normal' }}>{value}</Typography>
    </Box>
  );
};

export default function UsersDetailsForm() {
  const [user, setUser] = useState(null);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);
  const { userId } = useParams();
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const navigate = useNavigate();


  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const url = USERS_GET_BY_ID_LIMITED_URL(userId);
        console.log("Fetching data from URL: ", url);
        const response = await axiosInstance.get(url);
        setUser(response.data);
        setError(null);
      } catch (err) {
        setError("Failed to fetch user data");
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [userId]);

  if (loading) {
    return <Typography>Loading...</Typography>;
  }

  if (error) {
    return (
      <Box>
        <Typography color="error">{error}</Typography>
        <Button
          variant="outlined"
          color="primary"
          onClick={() => window.location.reload()}
        >
          Retry
        </Button>
      </Box>
    );
  }

  return (
    <Box m={4} style={{ backgroundColor: colors.blueAccent[800], padding: '24px',  borderRadius: '12px' }}>
      <Typography variant="h3" gutterBottom style={{ fontWeight: "bold", marginBottom: '40px' }}>
        User Details
      </Typography>

      <Card elevation={4} style={{ backgroundColor: colors.blueAccent[700], marginBottom: '24px' }}>
        <CardContent>
          <Typography variant="h4" gutterBottom style={{ fontWeight: "bold", marginBottom: '20px' }}>
            Personal Info
          </Typography>
          <Box display="flex" alignItems="center" marginBottom={2}>
            <Avatar
              alt={`${user?.firstname} ${user?.lastname}`}
              src={BASE_WEB_URL + user?.profileImageUrl}
              style={{ width: '80px', height: '80px', marginRight: '24px' }}
            />
           <Box>
      <InfoPair label="First Name:" value={user?.firstname} />
      <InfoPair label="Last Name:" value={user?.lastname} />
      <InfoPair label="Username:" value={user?.userName} />
      <InfoPair label="Email:" value={user?.email} />
    </Box>
          </Box>
        </CardContent>
      </Card>

      <Card elevation={4} style={{ backgroundColor: colors.blueAccent[700] }}>
        <CardContent>
          <Typography variant="h4" gutterBottom style={{ fontWeight: "bold",  marginBottom: '20px'}}>
            Roles
          </Typography>
          <Table>
            <TableHead>
            </TableHead>
            <TableBody>
  {(user?.roles || []).map((role, index) => (
    <TableRow key={index}>
      <TableCell>
        <Chip 
          key={role || index} 
          label={role} 
          variant="outlined"
          style={{ border: '1px solid', fontSize: "1rem" }}
        />
      </TableCell>
    </TableRow>
  ))}
</TableBody>
          </Table>
        </CardContent>
      </Card>
      <Button
        variant="contained"
        style={{
          backgroundColor: colors.grey[700],
          fontSize: "0.8rem",
          fontWeight: "bold",
          marginTop: '20px',
          width: "100%"
        }}
        onClick={() => navigate(-1)} // navigating back to the previous page
      >
        Go Back
      </Button>
    </Box>
  );
}
