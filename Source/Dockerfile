# Use the latest Mono image as the base
FROM mono:latest

# Set environment variables
ENV OPENPDC_VERSION 2.9.148
ENV OPENPDC_GROUP openpdc
ENV OPENPDC_USER admin
ENV OPENPDC_PASS admin

# Install dependencies and tools
RUN apt-get update && apt-get install -y \
    wget \
    unzip \
    sqlite3 \
    build-essential \
    libpam0g-dev \
    openssl \
    passwd

# Create a new user and group
RUN groupadd -r $OPENPDC_GROUP && \
    sh -c 'useradd -r -g $OPENPDC_GROUP -d /home/$OPENPDC_USER -m -s /bin/bash -p $(openssl passwd -1 $OPENPDC_PASS) $OPENPDC_USER'

# Set password aging policies
RUN chage -M 99999 $OPENPDC_USER && \
    chage -m 0 $OPENPDC_USER && \
    chage -W 7 $OPENPDC_USER

# Download and unzip openPDC POSIX release
RUN wget https://github.com/GridProtectionAlliance/openPDC/releases/download/v${OPENPDC_VERSION}/openPDC-POSIX.zip && \
    unzip openPDC-POSIX.zip -d /opt && \
    rm openPDC-POSIX.zip

# Set the working directory
WORKDIR /opt/openPDC

# Generate a service certificate
RUN mono MonoGenCert.exe openPDC

# Enable local user auth for openPDC
RUN echo "Enabling security for openPDC..." && \
    cd UnixTools/ && \
    gcc -c -Wall -Werror -fpic GSF.POSIX.c && \
    gcc -shared -o GSF.POSIX.so GSF.POSIX.o -lpam -lpam_misc -lcrypt && \
    cp -v GSF.POSIX.so .. && \
    sed -i.backup -e '/name="SecureRemoteInteractions"/ s/value="False"/value="True"/' ../openPDC.exe.config

# Add user directly to the configuration database
RUN sqlite3 -line /opt/openPDC/ConfigurationCache/openPDC.db "INSERT INTO UserAccount(Name, DefaultNodeID) VALUES('${OPENPDC_USER}', (SELECT ID FROM Node));" && \
    sqlite3 -line /opt/openPDC/ConfigurationCache/openPDC.db "INSERT INTO ApplicationRoleUserAccount(ApplicationRoleID, UserAccountID) VALUES((SELECT ID FROM ApplicationRole WHERE Name = 'Administrator'), (SELECT ID FROM UserAccount WHERE Name = '${OPENPDC_USER}'));"

# Expose necessary ports
EXPOSE 8280 7165 6165 8900

# Start the openPDC service with the -RunAsConsole parameter
CMD ["mono", "openPDC.exe", "-RunAsConsole"]
