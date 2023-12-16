import ClientNavbar from "@/components/Client/MainSections/Navbar/ClientNavbar";
import ClientFooter from "@/components/Client/MainSections/Footer/ClientFooter";
import styles from "./ClientLayout.module.scss";
import { Outlet } from "react-router-dom";
import { CssBaseline, ThemeProvider } from "@mui/material";
import { createTheme } from "@mui/material/styles";

const theme = createTheme();

function ClientLayout() {
  return (
    <ThemeProvider theme={theme}>
        <CssBaseline />
        <div className={styles.root}>
          <div className={styles.navbar}>
            <ClientNavbar />
          </div>
          <main className={styles.content}>
            <div className={styles.rootContainer}>
              <Outlet />
            </div>
            <ClientFooter />
          </main>
        </div>
    </ThemeProvider>
  );
}

export default ClientLayout;
