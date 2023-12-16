import {
  Drawer,
  IconButton,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Box,
  Button,
  Typography,
} from "@mui/material";
import { useState } from "react";
import { NavLink, useNavigate  } from "react-router-dom";
import ClientRoutes from "@/routing/ClientRoutes";
import FormatListBulletedRoundedIcon from "@mui/icons-material/FormatListBulletedRounded";
import styles from "./Sidebar.module.scss";
import useAuth from '@/utils/useAuth';
import authRoutes from "@/routing/authRoutes";
import { findPathByLabel } from "@/utils/routingUtils";
import LoginIcon from "@mui/icons-material/Login";
import AppRegistrationIcon from "@mui/icons-material/AppRegistration";

function Sidebar() {
  const [open, setOpen] = useState(false);
  const routes = ClientRoutes[0].children;
  const { user } = useAuth();
  const navigate = useNavigate();

  return (
    <>
      <Drawer
        open={open}
        onClose={() => setOpen(false)}
        PaperProps={{ sx: { backgroundColor: "rgba(49,49,116,1)" } }}
      >
       <List>
       {user ? (
            <Box textAlign="center" mb={2}>
              <Typography variant="h5" sx={{ color: "white" }}>
                Welcome, {user.firstname} {user.lastname}
              </Typography>
            </Box>
          ) : (
            <Box display="flex" justifyContent="center" gap={1} mb={2}>
              <Button
                variant="outlined"
                sx={{ color: "white", borderColor: "white" }}
                startIcon={<LoginIcon />}
                onClick={() => navigate(findPathByLabel(authRoutes, "SignIn"))}
              >
                Login
              </Button>
              <Button
                variant="outlined"
                sx={{ color: "white", borderColor: "white" }}
                startIcon={<AppRegistrationIcon />}
                onClick={() => navigate(findPathByLabel(authRoutes, "SignUp"))}
              >
                Signup
              </Button>
            </Box>
          )}
          {routes.map((route, index) => (
            <ListItemButton key={index} component={NavLink} to={route.path}>
              <Box sx={{ display: 'flex', alignItems: 'center', gap: "0.5rem" }}>
                <ListItemIcon sx={{ color: "white", minWidth: 'unset' }}>
                  {route.icon}
                </ListItemIcon>
                <ListItemText sx={{ color: "white" }}>
                  {route.label}
                </ListItemText>
              </Box>
            </ListItemButton>
          ))}
        </List>
      </Drawer>

      <IconButton onClick={() => setOpen(!open)} sx={{ color: "white" }}>
        <FormatListBulletedRoundedIcon />
      </IconButton>
    </>
  );
}

export default Sidebar;
