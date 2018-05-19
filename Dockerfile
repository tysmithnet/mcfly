FROM ubuntu

# Install required packages
RUN apt-get update && apt-get install -y build-essential wget libunwind8 liblttng-ust0 libcurl3 libssl1.0.0 libuuid1 libkrb5-3 zlib1g

# Perform .NET install
RUN wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > /etc/apt/trusted.gpg.d/microsoft.asc.gpg && \
    wget -q https://packages.microsoft.com/config/ubuntu/18.04/prod.list > /etc/apt/sources.list.d/microsoft-prod.list && \
    apt-get install -y apt-transport-https && apt-get update && apt-get install dotnet-runtime-2.0.7